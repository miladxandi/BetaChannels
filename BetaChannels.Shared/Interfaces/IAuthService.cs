using BetaChannels.Shared.DTOs;

namespace BetaChannels.Shared.Interfaces;

public interface IAuthService
{
    Task<AuthResultDto> LoginAsync(LoginDto dto);
    Task<AuthResultDto> RegisterAsync(RegisterDto dto);
    Task LogoutAsync();
    Task<bool> IsAuthenticatedAsync();
    Task<Guid?> GetCurrentUserIdAsync();

    /// <summary>
    /// درخواست ارسال کد OTP به شماره موبایل (ورود/ثبت‌نام با شماره)
    /// </summary>
    Task<OtpRequestResultDto> RequestPhoneOtpAsync(string phone);

    /// <summary>
    /// تأیید کد OTP و دریافت توکن JWT
    /// </summary>
    Task<AuthResultDto> VerifyPhoneOtpAsync(string phone, string code);

    /// <summary>
    /// بازیابی توکن ذخیره‌شده (از SecureStorage)
    /// </summary>
    Task<string?> GetStoredTokenAsync();
}
