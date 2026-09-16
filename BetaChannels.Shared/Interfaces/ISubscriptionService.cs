using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Interfaces;

public interface ISubscriptionService
{
    Task<List<SubscriptionPlanDto>> GetAvailablePlansAsync();
    Task<SubscriptionDto?> GetActiveSubscriptionAsync(Guid userId);
    Task<SubscriptionDto> SubscribeAsync(Guid userId, SubscriptionType planType);
    Task<bool> CancelSubscriptionAsync(Guid subscriptionId);
}
