using BetaChannels.Shared.DTOs;

namespace BetaChannels.Shared.Interfaces;

public interface IPortfolioService
{
    Task<List<PortfolioItemDto>> GetPortfolioByFreelancerAsync(Guid freelancerId);
    Task<PortfolioItemDto?> GetPortfolioItemByIdAsync(Guid id);
    Task<PortfolioItemDto> CreatePortfolioItemAsync(Guid freelancerId, CreatePortfolioItemDto dto);
    Task<bool> DeletePortfolioItemAsync(Guid id);
}
