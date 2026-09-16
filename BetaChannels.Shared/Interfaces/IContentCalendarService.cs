using BetaChannels.Shared.DTOs;

namespace BetaChannels.Shared.Interfaces;

public interface IContentCalendarService
{
    Task<List<ContentCalendarDto>> GetCalendarAsync(Guid userId, DateTime? month = null);
    Task<ContentCalendarDto> CreateEventAsync(Guid userId, CreateContentCalendarDto dto);
    Task<ContentCalendarDto> UpdateEventAsync(Guid eventId, CreateContentCalendarDto dto);
    Task<bool> DeleteEventAsync(Guid eventId);
}
