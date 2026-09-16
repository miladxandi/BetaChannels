using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.DTOs;

public class ContentCalendarDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public SocialPlatform Platform { get; set; }
    public ContentStatus Status { get; set; }
    public string? ContentUrl { get; set; }
}

public class CreateContentCalendarDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public SocialPlatform Platform { get; set; }
}
