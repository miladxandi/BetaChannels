namespace BetaChannels.Shared.Models;

public class Review
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Guid ReviewerId { get; set; }
    public Guid RevieweeId { get; set; }
    public Guid? ServiceId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
