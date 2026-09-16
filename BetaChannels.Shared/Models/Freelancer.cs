using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Models;

public class Freelancer : User
{
    public string Bio { get; set; } = string.Empty;
    public List<ServiceCategory> Skills { get; set; } = new();
    public double Rating { get; set; }
    public int TotalReviews { get; set; }
    public decimal HourlyRate { get; set; }
    public FreelancerStatus Status { get; set; } = FreelancerStatus.Available;
    public int CompletedProjects { get; set; }
    public SubscriptionType Subscription { get; set; } = SubscriptionType.Free;
    public DateTime SubscriptionExpiry { get; set; }
    public List<string> SocialMediaLinks { get; set; } = new();
    public List<PortfolioItem> Portfolio { get; set; } = new();
    public List<Service> Services { get; set; } = new();
}
