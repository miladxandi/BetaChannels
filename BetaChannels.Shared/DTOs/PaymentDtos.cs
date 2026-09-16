using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.DTOs;

public class PaymentDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public PaymentStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}

public class CreatePaymentDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid FreelancerId { get; set; }
    public Guid EmployerId { get; set; }
}
