using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Shared.Services;

public class MockAuthService : IAuthService
{
    private Guid? _currentUserId;
    private bool _isAuthenticated;

    public Task<AuthResultDto> LoginAsync(LoginDto dto)
    {
        // Mock: accept any login
        _currentUserId = Guid.NewGuid();
        _isAuthenticated = true;
        return Task.FromResult(new AuthResultDto
        {
            Success = true,
            Token = "mock-jwt-token",
            UserId = _currentUserId
        });
    }

    public Task<AuthResultDto> RegisterAsync(RegisterDto dto)
    {
        _currentUserId = Guid.NewGuid();
        _isAuthenticated = true;
        return Task.FromResult(new AuthResultDto
        {
            Success = true,
            Token = "mock-jwt-token",
            UserId = _currentUserId
        });
    }

    public Task LogoutAsync()
    {
        _currentUserId = null;
        _isAuthenticated = false;
        return Task.CompletedTask;
    }

    public Task<bool> IsAuthenticatedAsync() => Task.FromResult(_isAuthenticated);
    public Task<Guid?> GetCurrentUserIdAsync() => Task.FromResult(_currentUserId);
}
