using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Shared.Services;

public class MockPortfolioService : IPortfolioService
{
    private readonly List<PortfolioItemDto> _items = new()
    {
        new() { Id = Guid.NewGuid(), Title = "ویدیو معرفی رستوران", Description = "ویدیو تبلیغاتی برای رستوران سنتی", Category = ServiceCategory.Videography, Likes = 234, Views = 5600 },
        new() { Id = Guid.NewGuid(), Title = "کمپین اینستاگرام برند پوشاک", Description = "مدیریت و تولید محتوای ۳ ماهه", Category = ServiceCategory.InstagramAdmin, Likes = 890, Views = 12000 },
        new() { Id = Guid.NewGuid(), Title = "سایت فروشگاهی", Description = "طراحی سایت فروشگاهی با ووکامرس", Category = ServiceCategory.WebDesign, Likes = 156, Views = 3400 }
    };

    public Task<List<PortfolioItemDto>> GetPortfolioByFreelancerAsync(Guid freelancerId)
        => Task.FromResult(_items);

    public Task<PortfolioItemDto?> GetPortfolioItemByIdAsync(Guid id)
        => Task.FromResult(_items.FirstOrDefault(p => p.Id == id));

    public Task<PortfolioItemDto> CreatePortfolioItemAsync(Guid freelancerId, CreatePortfolioItemDto dto)
    {
        var item = new PortfolioItemDto
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            ThumbnailUrl = dto.ThumbnailUrl,
            VideoUrl = dto.VideoUrl,
            Category = dto.Category
        };
        _items.Add(item);
        return Task.FromResult(item);
    }

    public Task<bool> DeletePortfolioItemAsync(Guid id)
    {
        var item = _items.FirstOrDefault(p => p.Id == id);
        if (item != null) _items.Remove(item);
        return Task.FromResult(item != null);
    }
}
