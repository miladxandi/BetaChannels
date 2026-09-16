using BetaChannels.Shared.DTOs;

namespace BetaChannels.Shared.Interfaces;

public interface IPaymentService
{
    Task<List<PaymentDto>> GetPaymentsByUserAsync(Guid userId);
    Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto dto);
    Task<PaymentDto?> GetPaymentByIdAsync(Guid id);
    Task<decimal> GetTotalEarningsAsync(Guid freelancerId);
    Task<decimal> GetTotalSpentAsync(Guid employerId);
}
