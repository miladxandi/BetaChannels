using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Shared.Services;

/// <summary>
/// سرویس احراز هویت واقعی — متصل به بک‌اند ادمتریکس
/// از شماره موبایل + OTP استفاده می‌کند.
/// توکن JWT در SecureStorage ذخیره می‌شود.
/// </summary>
public class AdmetrixAuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private Guid? _currentUserId;
    private bool _isAuthenticated;
    private string? _token;

    private const string TokenKey = "beta_auth_token";
    private const string UserIdKey = "beta_user_id";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true,
    };

    public AdmetrixAuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// مقداردهی اولیه از توکن ذخیره‌شده (در شروع اپ)
    /// </summary>
    public async Task InitializeAsync()
    {
        _token = await SecureStorage.GetAsync(TokenKey);
        var userIdStr = await SecureStorage.GetAsync(UserIdKey);

        if (!string.IsNullOrEmpty(_token) && Guid.TryParse(userIdStr, out var userId))
        {
            _currentUserId = userId;
            _isAuthenticated = true;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);
        }
    }

    public async Task<AuthResultDto> LoginAsync(LoginDto dto)
    {
        // برای سازگاری با رابط قدیمی — از OTP استفاده می‌کنیم
        // (در اپ جدید مستقیماً از RequestPhoneOtpAsync / VerifyPhoneOtpAsync استفاده شود)
        return new AuthResultDto
        {
            Success = false,
            ErrorMessage = "لطفاً از ورود با شماره موبایل استفاده کنید",
        };
    }

    public async Task<AuthResultDto> RegisterAsync(RegisterDto dto)
    {
        return new AuthResultDto
        {
            Success = false,
            ErrorMessage = "لطفاً از ثبت‌نام با شماره موبایل استفاده کنید",
        };
    }

    public async Task<OtpRequestResultDto> RequestPhoneOtpAsync(string phone)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(
                "/api/beta/auth/phone-request",
                new { phone },
                JsonOptions);

            var result = await response.Content.ReadFromJsonAsync<OtpRequestResultDto>(JsonOptions);
            return result ?? new OtpRequestResultDto
            {
                Success = false,
                ErrorMessage = "پاسخ نامعتبر از سرور",
            };
        }
        catch (HttpRequestException ex)
        {
            return new OtpRequestResultDto
            {
                Success = false,
                ErrorMessage = $"خطا در ارتباط با سرور: {ex.Message}",
            };
        }
    }

    public async Task<AuthResultDto> VerifyPhoneOtpAsync(string phone, string code)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(
                "/api/beta/auth/phone-verify",
                new { phone, code },
                JsonOptions);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                return new AuthResultDto
                {
                    Success = false,
                    ErrorMessage = $"کد تأیید نامعتبر است: {errorText}",
                };
            }

            var result = await response.Content.ReadFromJsonAsync<AuthResultDto>(JsonOptions);
            if (result is not { Success: true } || string.IsNullOrEmpty(result.Token))
            {
                return new AuthResultDto
                {
                    Success = false,
                    ErrorMessage = "پاسخ نامعتبر از سرور",
                };
            }

            // ذخیره توکن و شناسه کاربر
            _token = result.Token;
            _currentUserId = result.UserId;
            _isAuthenticated = true;

            await SecureStorage.SetAsync(TokenKey, _token);
            if (result.UserId.HasValue)
                await SecureStorage.SetAsync(UserIdKey, result.UserId.Value.ToString());

            // تنظیم هدر Authorization برای درخواست‌های بعدی
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            return result;
        }
        catch (HttpRequestException ex)
        {
            return new AuthResultDto
            {
                Success = false,
                ErrorMessage = $"خطا در ارتباط با سرور: {ex.Message}",
            };
        }
    }

    public async Task LogoutAsync()
    {
        _token = null;
        _currentUserId = null;
        _isAuthenticated = false;

        SecureStorage.Remove(TokenKey);
        SecureStorage.Remove(UserIdKey);

        _httpClient.DefaultRequestHeaders.Authorization = null;

        // اطلاع به سرور (اختیاری — اگر خطا داد مهم نیست)
        try
        {
            await _httpClient.PostAsync("/api/auth/logout", null);
        }
        catch { /* ignore */ }
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        if (_isAuthenticated) return true;

        // بررسی از SecureStorage
        _token = await SecureStorage.GetAsync(TokenKey);
        return !string.IsNullOrEmpty(_token);
    }

    public async Task<Guid?> GetCurrentUserIdAsync()
    {
        if (_currentUserId.HasValue) return _currentUserId;

        var userIdStr = await SecureStorage.GetAsync(UserIdKey);
        if (Guid.TryParse(userIdStr, out var userId))
            return userId;

        return null;
    }

    public async Task<string?> GetStoredTokenAsync()
    {
        if (!string.IsNullOrEmpty(_token)) return _token;
        return await SecureStorage.GetAsync(TokenKey);
    }

    /// <summary>
    /// تنظیم توکن از deep link (مثلاً بعد از OAuth دیوار)
    /// </summary>
    public async Task SetTokenFromDeepLinkAsync(string token, Guid userId)
    {
        _token = token;
        _currentUserId = userId;
        _isAuthenticated = true;

        await SecureStorage.SetAsync(TokenKey, token);
        await SecureStorage.SetAsync(UserIdKey, userId.ToString());

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }
}
