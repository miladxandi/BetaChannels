using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.DTOs;

public class FreelancerSearchDto
{
    public string? Keyword { get; set; }
    public ServiceCategory? Category { get; set; }
    public decimal? MinRate { get; set; }
    public decimal? MaxRate { get; set; }
    public double? MinRating { get; set; }
    public FreelancerStatus? Status { get; set; }
}

public class FreelancerProfileDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public List<ServiceCategory> Skills { get; set; } = new();
    public double Rating { get; set; }
    public int TotalReviews { get; set; }
    public decimal HourlyRate { get; set; }
    public FreelancerStatus Status { get; set; }
    public int CompletedProjects { get; set; }
    public string? AvatarUrl { get; set; }
    public List<PortfolioItemDto> Portfolio { get; set; } = new();
    public List<ServiceDto> Services { get; set; } = new();
}

public class FreelancerProfileUpdateDto
{
    public string? Bio { get; set; }
    public List<ServiceCategory>? Skills { get; set; }
    public decimal? HourlyRate { get; set; }
    public List<string>? SocialMediaLinks { get; set; }
}
