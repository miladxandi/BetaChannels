using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Models;

public class Subscription
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public SubscriptionType Type { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public List<string> Features { get; set; } = new();
    public decimal Price { get; set; }
}
