using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Models;

public class PortfolioItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ThumbnailUrl { get; set; }
    public string? VideoUrl { get; set; }
    public Guid FreelancerId { get; set; }
    public ServiceCategory Category { get; set; }
    public int Likes { get; set; }
    public int Views { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
