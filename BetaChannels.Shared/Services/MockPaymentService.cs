using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Shared.Services;

public class MockPaymentService : IPaymentService
{
    private readonly List<PaymentDto> _payments = new()
    {
        new() { Id = Guid.NewGuid(), Amount = 5_000_000, Description = "فیلم‌برداری مراسم", Status = PaymentStatus.Completed, CreatedAt = DateTime.UtcNow.AddDays(-10), CompletedAt = DateTime.UtcNow.AddDays(-9) },
        new() { Id = Guid.NewGuid(), Amount = 2_000_000, Description = "تدوین ویدیو", Status = PaymentStatus.Completed, CreatedAt = DateTime.UtcNow.AddDays(-5), CompletedAt = DateTime.UtcNow.AddDays(-4) },
        new() { Id = Guid.NewGuid(), Amount = 8_000_000, Description = "مدیریت اینستاگرام - ماهانه", Status = PaymentStatus.Pending, CreatedAt = DateTime.UtcNow.AddDays(-1) }
    };

    public Task<List<PaymentDto>> GetPaymentsByUserAsync(Guid userId)
        => Task.FromResult(_payments);

    public Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto dto)
    {
        var payment = new PaymentDto
        {
            Id = Guid.NewGuid(),
            Amount = dto.Amount,
            Description = dto.Description,
            Status = PaymentStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
        _payments.Add(payment);
        return Task.FromResult(payment);
    }

    public Task<PaymentDto?> GetPaymentByIdAsync(Guid id)
        => Task.FromResult(_payments.FirstOrDefault(p => p.Id == id));

    public Task<decimal> GetTotalEarningsAsync(Guid freelancerId)
        => Task.FromResult(_payments.Where(p => p.Status == PaymentStatus.Completed).Sum(p => p.Amount));

    public Task<decimal> GetTotalSpentAsync(Guid employerId)
        => Task.FromResult(_payments.Where(p => p.Status == PaymentStatus.Completed).Sum(p => p.Amount));
}
