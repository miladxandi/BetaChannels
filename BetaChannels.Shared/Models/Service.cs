using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Models;

public class Service
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ServiceCategory Category { get; set; }
    public decimal Price { get; set; }
    public int DurationDays { get; set; }
    public Guid FreelancerId { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
