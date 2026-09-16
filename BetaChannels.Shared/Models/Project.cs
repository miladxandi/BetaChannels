using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Models;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ServiceCategory Category { get; set; }
    public decimal Budget { get; set; }
    public Guid EmployerId { get; set; }
    public Guid? FreelancerId { get; set; }
    public bool IsOpen { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? Deadline { get; set; }
    public DateTime? CompletedAt { get; set; }
}
