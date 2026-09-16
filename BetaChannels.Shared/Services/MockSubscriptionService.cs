using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Helpers;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Shared.Services;

public class MockSubscriptionService : ISubscriptionService
{
    public Task<List<SubscriptionPlanDto>> GetAvailablePlansAsync()
    {
        return Task.FromResult(new List<SubscriptionPlanDto>
        {
            new() { Type = SubscriptionType.Basic, Name = "پایه", Price = AppConstants.SubscriptionPrices.BasicMonthly, DurationDays = 30, Features = AppConstants.Features.BasicFeatures },
            new() { Type = SubscriptionType.Premium, Name = "حرفه‌ای", Price = AppConstants.SubscriptionPrices.PremiumMonthly, DurationDays = 30, Features = AppConstants.Features.PremiumFeatures, IsPopular = true },
            new() { Type = SubscriptionType.VIP, Name = "ویژه", Price = AppConstants.SubscriptionPrices.VIPMonthly, DurationDays = 30, Features = AppConstants.Features.VIPFeatures }
        });
    }

    public Task<SubscriptionDto?> GetActiveSubscriptionAsync(Guid userId)
    {
        return Task.FromResult<SubscriptionDto?>(new SubscriptionDto
        {
            Id = Guid.NewGuid(),
            Type = SubscriptionType.Premium,
            StartDate = DateTime.UtcNow.AddDays(-15),
            EndDate = DateTime.UtcNow.AddDays(15),
            IsActive = true,
            Features = AppConstants.Features.PremiumFeatures,
            Price = AppConstants.SubscriptionPrices.PremiumMonthly
        });
    }

    public Task<SubscriptionDto> SubscribeAsync(Guid userId, SubscriptionType planType)
    {
        var plan = GetAvailablePlansAsync().Result.First(p => p.Type == planType);
        return Task.FromResult(new SubscriptionDto
        {
            Id = Guid.NewGuid(),
            Type = planType,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(plan.DurationDays),
            IsActive = true,
            Features = plan.Features,
            Price = plan.Price
        });
    }

    public Task<bool> CancelSubscriptionAsync(Guid subscriptionId)
        => Task.FromResult(true);
}
