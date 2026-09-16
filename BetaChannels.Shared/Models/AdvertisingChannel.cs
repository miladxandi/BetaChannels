using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Models;

public class AdvertisingChannel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public SocialPlatform Platform { get; set; }
    public string ChannelUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Followers { get; set; }
    public decimal AdvertisingPrice { get; set; }
    public string? Industry { get; set; }
    public double EngagementRate { get; set; }
}
