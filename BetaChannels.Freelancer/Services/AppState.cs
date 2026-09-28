using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Interfaces;
using BetaChannels.Shared.Services;

namespace BetaChannels.Freelancer.Services;

public class AppState
{
    private readonly IAuthService _authService;
    private Guid? _userId;
    private bool _isAuthenticated;
    private bool _initialized;

    public AppState(IAuthService authService)
    {
        _authService = authService;
    }

    public Guid? UserId
    {
        get => _userId;
        set => _userId = value;
    }

    public bool IsAuthenticated
    {
        get => _isAuthenticated;
        set => _isAuthenticated = value;
    }

    public string? UserFullName { get; set; }

    /// <summary>
    /// بارگذاری وضعیت احراز هویت از حافظه امن (در شروع اپ فراخوانی شود)
    /// </summary>
    public async Task InitializeAsync()
    {
        if (_initialized) return;
        _initialized = true;

        if (_authService is AdmetrixAuthService admetrixAuth)
        {
            await admetrixAuth.InitializeAsync();
        }

        _isAuthenticated = await _authService.IsAuthenticatedAsync();
        _userId = await _authService.GetCurrentUserIdAsync();

        if (_isAuthenticated)
        {
            var token = await _authService.GetStoredTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                UserFullName = "فریلنسر";
            }
        }
    }

    public async Task<bool> LoginAsync(LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);
        if (result.Success)
        {
            _userId = result.UserId;
            _isAuthenticated = true;
        }
        return result.Success;
    }

    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);
        if (result.Success)
        {
            _userId = result.UserId;
            _isAuthenticated = true;
        }
        return result.Success;
    }

    public async Task LogoutAsync()
    {
        await _authService.LogoutAsync();
        _userId = null;
        _isAuthenticated = false;
        UserFullName = null;
    }
}
