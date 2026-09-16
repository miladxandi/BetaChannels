using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.DTOs;

public class PortfolioItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ThumbnailUrl { get; set; }
    public string? VideoUrl { get; set; }
    public ServiceCategory Category { get; set; }
    public int Likes { get; set; }
    public int Views { get; set; }
}

public class CreatePortfolioItemDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ThumbnailUrl { get; set; }
    public string? VideoUrl { get; set; }
    public ServiceCategory Category { get; set; }
}
