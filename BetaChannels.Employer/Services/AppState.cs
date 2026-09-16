using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Employer.Services;

public class AppState
{
    private readonly IAuthService _authService;
    private Guid? _userId;
    private bool _isAuthenticated;

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
