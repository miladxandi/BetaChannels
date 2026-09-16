using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Shared.Services;

public class MockContentCalendarService : IContentCalendarService
{
    private readonly List<ContentCalendarDto> _events = new()
    {
        new() { Id = Guid.NewGuid(), Title = "پست معرفی محصول", Description = "پست اینستاگرام برای معرفی محصول جدید", ScheduledDate = DateTime.UtcNow.AddDays(2), Platform = SocialPlatform.Instagram, Status = ContentStatus.Scheduled },
        new() { Id = Guid.NewGuid(), Title = "استوری روزانه", Description = "استوری انگیزشی", ScheduledDate = DateTime.UtcNow.AddDays(1), Platform = SocialPlatform.Instagram, Status = ContentStatus.Draft },
        new() { Id = Guid.NewGuid(), Title = "ویدیو یوتیوب", Description = "آموزش تدوین با پریمیر", ScheduledDate = DateTime.UtcNow.AddDays(5), Platform = SocialPlatform.YouTube, Status = ContentStatus.Scheduled },
        new() { Id = Guid.NewGuid(), Title = "پست تلگرام", Description = "اخبار هفتگی کانال", ScheduledDate = DateTime.UtcNow.AddDays(3), Platform = SocialPlatform.Telegram, Status = ContentStatus.Published }
    };

    public Task<List<ContentCalendarDto>> GetCalendarAsync(Guid userId, DateTime? month = null)
    {
        var query = _events.AsEnumerable();
        if (month.HasValue)
        {
            var start = new DateTime(month.Value.Year, month.Value.Month, 1);
            var end = start.AddMonths(1);
            query = query.Where(e => e.ScheduledDate >= start && e.ScheduledDate < end);
        }
        return Task.FromResult(query.ToList());
    }

    public Task<ContentCalendarDto> CreateEventAsync(Guid userId, CreateContentCalendarDto dto)
    {
        var ev = new ContentCalendarDto
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            ScheduledDate = dto.ScheduledDate,
            Platform = dto.Platform,
            Status = ContentStatus.Draft
        };
        _events.Add(ev);
        return Task.FromResult(ev);
    }

    public Task<ContentCalendarDto> UpdateEventAsync(Guid eventId, CreateContentCalendarDto dto)
    {
        var ev = _events.First(e => e.Id == eventId);
        ev.Title = dto.Title;
        ev.Description = dto.Description;
        ev.ScheduledDate = dto.ScheduledDate;
        ev.Platform = dto.Platform;
        return Task.FromResult(ev);
    }

    public Task<bool> DeleteEventAsync(Guid eventId)
    {
        var ev = _events.FirstOrDefault(e => e.Id == eventId);
        if (ev != null) _events.Remove(ev);
        return Task.FromResult(ev != null);
    }
}
