using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.DTOs;

public class SubscriptionDto
{
    public Guid Id { get; set; }
    public SubscriptionType Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public List<string> Features { get; set; } = new();
    public decimal Price { get; set; }
}

public class SubscriptionPlanDto
{
    public SubscriptionType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int DurationDays { get; set; }
    public List<string> Features { get; set; } = new();
    public bool IsPopular { get; set; }
}
