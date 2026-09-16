using BetaChannels.Shared.Models;

namespace BetaChannels.Shared.Interfaces;

public interface IAdvertisingService
{
    Task<List<AdvertisingChannel>> GetChannelsByIndustryAsync(string? industry);
    Task<List<AdvertisingChannel>> GetChannelsByPlatformAsync(Enums.SocialPlatform platform);
    Task<AdvertisingChannel?> GetChannelByIdAsync(Guid id);
}
