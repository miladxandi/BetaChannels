using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Shared.Services;

public class MockAuthService : IAuthService
{
    private Guid? _currentUserId;
    private bool _isAuthenticated;
    private string? _token;

    public Task<AuthResultDto> LoginAsync(LoginDto dto)
    {
        // Mock: accept any login
        _currentUserId = Guid.NewGuid();
        _isAuthenticated = true;
        _token = "mock-jwt-token";
        return Task.FromResult(new AuthResultDto
        {
            Success = true,
            Token = _token,
            UserId = _currentUserId
        });
    }

    public Task<AuthResultDto> RegisterAsync(RegisterDto dto)
    {
        _currentUserId = Guid.NewGuid();
        _isAuthenticated = true;
        _token = "mock-jwt-token";
        return Task.FromResult(new AuthResultDto
        {
            Success = true,
            Token = _token,
            UserId = _currentUserId
        });
    }

    public Task LogoutAsync()
    {
        _currentUserId = null;
        _isAuthenticated = false;
        _token = null;
        return Task.CompletedTask;
    }

    public Task<bool> IsAuthenticatedAsync() => Task.FromResult(_isAuthenticated);
    public Task<Guid?> GetCurrentUserIdAsync() => Task.FromResult(_currentUserId);

    public Task<OtpRequestResultDto> RequestPhoneOtpAsync(string phone)
    {
        return Task.FromResult(new OtpRequestResultDto
        {
            Success = true,
            TtlMinutes = 5,
            ResendAfter = 60,
            DevCode = "123456"
        });
    }

    public Task<AuthResultDto> VerifyPhoneOtpAsync(string phone, string code)
    {
        _currentUserId = Guid.NewGuid();
        _isAuthenticated = true;
        _token = "mock-jwt-token";
        return Task.FromResult(new AuthResultDto
        {
            Success = true,
            Token = _token,
            UserId = _currentUserId,
            Name = "کاربر آزمایشی",
            Phone = phone,
        });
    }

    public Task<string?> GetStoredTokenAsync() => Task.FromResult(_token);
}
