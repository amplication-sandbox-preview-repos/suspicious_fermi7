using TimeAndCalendarManagement.APIs.Common;
using TimeAndCalendarManagement.APIs.Dtos;

namespace TimeAndCalendarManagement.APIs;

public interface IEventsService
{
    /// <summary>
    /// Create one Event
    /// </summary>
    public Task<EventDto> CreateEvent(EventCreateInput eventDto);

    /// <summary>
    /// Delete one Event
    /// </summary>
    public Task DeleteEvent(EventIdDto idDto);

    /// <summary>
    /// Meta data about Event records
    /// </summary>
    public Task<MetadataDto> EventsMeta(EventFindMany findManyArgs);

    /// <summary>
    /// Find many Events
    /// </summary>
    public Task<List<EventDto>> Events(EventFindMany findManyArgs);

    /// <summary>
    /// Get one Event
    /// </summary>
    public Task<EventDto> Event(EventIdDto idDto);

    /// <summary>
    /// Update one Event
    /// </summary>
    public Task UpdateEvent(EventIdDto idDto, EventUpdateInput updateDto);
}
