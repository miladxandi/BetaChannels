using BetaChannels.Shared.DTOs;

namespace BetaChannels.Shared.Interfaces;

public interface IAuthService
{
    Task<AuthResultDto> LoginAsync(LoginDto dto);
    Task<AuthResultDto> RegisterAsync(RegisterDto dto);
    Task LogoutAsync();
    Task<bool> IsAuthenticatedAsync();
    Task<Guid?> GetCurrentUserIdAsync();
}
