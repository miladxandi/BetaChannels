using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Shared.Services;

public class MockServiceService : IServiceService
{
    private readonly List<ServiceDto> _services = new()
    {
        new() { Id = Guid.NewGuid(), Title = "فیلم‌برداری مراسم", Description = "فیلم‌برداری حرفه‌ای مراسم‌ها با تجهیزات کامل", Category = ServiceCategory.Videography, Price = 5_000_000, DurationDays = 1, Rating = 4.8, ReviewCount = 15 },
        new() { Id = Guid.NewGuid(), Title = "تدوین ویدیو یوتیوب", Description = "تدوین حرفه‌ای ویدیو برای یوتیوب با افکت و موشن", Category = ServiceCategory.VideoEditing, Price = 2_000_000, DurationDays = 3, Rating = 4.9, ReviewCount = 22 },
        new() { Id = Guid.NewGuid(), Title = "مدیریت اینستاگرام", Description = "مدیریت کامل پیج اینستاگرام شامل تولید محتوا و استوری", Category = ServiceCategory.InstagramAdmin, Price = 8_000_000, DurationDays = 30, Rating = 4.7, ReviewCount = 31 },
        new() { Id = Guid.NewGuid(), Title = "ساخت سایت وردپرس", Description = "طراحی و راه‌اندازی سایت وردپرس با قالب اختصاصی", Category = ServiceCategory.WebDesign, Price = 15_000_000, DurationDays = 14, Rating = 4.6, ReviewCount = 18 },
        new() { Id = Guid.NewGuid(), Title = "سئو سایت", Description = "بهینه‌سازی سایت برای موتورهای جستجو", Category = ServiceCategory.SEO, Price = 6_000_000, DurationDays = 30, Rating = 4.5, ReviewCount = 12 }
    };

    public Task<List<ServiceDto>> GetServicesByFreelancerAsync(Guid freelancerId)
        => Task.FromResult(_services.Where(s => true).ToList());

    public Task<ServiceDto?> GetServiceByIdAsync(Guid id)
        => Task.FromResult(_services.FirstOrDefault(s => s.Id == id));

    public Task<ServiceDto> CreateServiceAsync(Guid freelancerId, CreateServiceDto dto)
    {
        var service = new ServiceDto
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            Category = dto.Category,
            Price = dto.Price,
            DurationDays = dto.DurationDays
        };
        _services.Add(service);
        return Task.FromResult(service);
    }

    public Task<ServiceDto> UpdateServiceAsync(Guid serviceId, CreateServiceDto dto)
    {
        var service = _services.First(s => s.Id == serviceId);
        service.Title = dto.Title;
        service.Description = dto.Description;
        service.Category = dto.Category;
        service.Price = dto.Price;
        service.DurationDays = dto.DurationDays;
        return Task.FromResult(service);
    }

    public Task<bool> DeleteServiceAsync(Guid serviceId)
    {
        var service = _services.FirstOrDefault(s => s.Id == serviceId);
        if (service != null) _services.Remove(service);
        return Task.FromResult(service != null);
    }

    public Task<List<ServiceDto>> GetFeaturedServicesAsync()
        => Task.FromResult(_services.OrderByDescending(s => s.Rating).Take(5).ToList());
}
