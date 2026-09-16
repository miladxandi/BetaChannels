using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Models;

public class ContentCalendar
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public SocialPlatform Platform { get; set; }
    public ContentStatus Status { get; set; } = ContentStatus.Draft;
    public Guid FreelancerId { get; set; }
    public Guid? EmployerId { get; set; }
    public string? ContentUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
