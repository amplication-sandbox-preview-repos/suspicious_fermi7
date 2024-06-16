using TimeAndCalendarManagement.APIs;
using TimeAndCalendarManagement.Infrastructure;
using TimeAndCalendarManagement.APIs.Dtos;
using TimeAndCalendarManagement.Infrastructure.Models;
using TimeAndCalendarManagement.APIs.Errors;
using TimeAndCalendarManagement.APIs.Extensions;
using TimeAndCalendarManagement.APIs.Common;
using Microsoft.EntityFrameworkCore;

namespace TimeAndCalendarManagement.APIs;

public abstract class EventsServiceBase : IEventsService
{
    protected readonly TimeAndCalendarManagementDbContext _context;
    public EventsServiceBase(TimeAndCalendarManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Event
    /// </summary>
    public async Task<EventDto> CreateEvent(EventCreateInput createDto)
    {
        var event = new Event
                  {
              CreatedAt = createDto.CreatedAt,
UpdatedAt = createDto.UpdatedAt
};
    
          if (createDto.Id != null){
            event.Id = createDto.Id;
}


_context.Events.Add(event);
await _context.SaveChangesAsync();

var result = await _context.FindAsync<Event>(event.Id);
    
            if (result == null)
            {
    throw new NotFoundException();
}
    
            return result.ToDto();
}

/// <summary>
/// Delete one Event
/// </summary>
public async Task DeleteEvent(EventIdDto idDto)
{
    var event = await _context.Events.FindAsync(idDto.Id);
    if (event == null)
      {
        throw new NotFoundException();
    }

    _context.Events.Remove(event);
    await _context.SaveChangesAsync();
}

/// <summary>
/// Meta data about Event records
/// </summary>
public async Task<MetadataDto> EventsMeta(EventFindMany findManyArgs)
{

    var count = await _context
.Events
.ApplyWhere(findManyArgs.Where)
.CountAsync();

    return new MetadataDto { Count = count };
}

/// <summary>
/// Find many Events
/// </summary>
public async Task<List<EventDto>> Events(EventFindMany findManyArgs)
{
    var events = await _context
        .Events

.ApplyWhere(findManyArgs.Where)
.ApplySkip(findManyArgs.Skip)
.ApplyTake(findManyArgs.Take)
.ApplyOrderBy(findManyArgs.SortBy)
.ToListAsync();
    return events.ConvertAll(event => event.ToDto());
}

/// <summary>
/// Get one Event
/// </summary>
public async Task<EventDto> Event(EventIdDto idDto)
{
    var events = await this.Events(
            new EventFindMany { Where = new EventWhereInput { Id = idDto.Id } }
);
    var event = events.FirstOrDefault();
    if (event == null)
    {
        throw new NotFoundException();
    }

    return event;
}

/// <summary>
/// Update one Event
/// </summary>
public async Task UpdateEvent(EventIdDto idDto, EventUpdateInput updateDto)
{
    var event = updateDto.ToModel(idDto);



    _context.Entry(event).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!_context.Events.Any(e => e.Id == event.Id))
        {
            throw new NotFoundException();
        }
        else
        {
            throw;
        }
    }
}

}
