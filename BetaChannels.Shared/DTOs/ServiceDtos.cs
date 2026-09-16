using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.DTOs;

public class ServiceDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ServiceCategory Category { get; set; }
    public decimal Price { get; set; }
    public int DurationDays { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public bool IsFeatured { get; set; }
}

public class CreateServiceDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ServiceCategory Category { get; set; }
    public decimal Price { get; set; }
    public int DurationDays { get; set; }
}
