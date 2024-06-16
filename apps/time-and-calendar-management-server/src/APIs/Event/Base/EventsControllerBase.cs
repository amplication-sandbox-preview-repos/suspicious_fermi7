using TimeAndCalendarManagement.APIs;
using Microsoft.AspNetCore.Mvc;
using TimeAndCalendarManagement.APIs.Dtos;
using TimeAndCalendarManagement.APIs.Errors;
using TimeAndCalendarManagement.APIs.Common;

namespace TimeAndCalendarManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EventsControllerBase : ControllerBase
{
    protected readonly IEventsService _service;
    public EventsControllerBase(IEventsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Event
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<EventDto>> CreateEvent(EventCreateInput input)
    {
        var event = await _service.CreateEvent(input);
        
    return CreatedAtAction(nameof(Event), new { id = event.Id }, event); }

    /// <summary>
    /// Delete one Event
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEvent([FromRoute()]
    EventIdDto idDto)
    {
        try
        {
            await _service.DeleteEvent(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Meta data about Event records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EventsMeta([FromQuery()]
    EventFindMany filter)
    {
        return Ok(await _service.EventsMeta(filter));
    }

    /// <summary>
    /// Find many Events
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<EventDto>>> Events([FromQuery()]
    EventFindMany filter)
    {
        return Ok(await _service.Events(filter));
    }

    /// <summary>
    /// Get one Event
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<EventDto>> Event([FromRoute()]
    EventIdDto idDto)
    {
        try
        {
            return await _service.Event(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Event
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEvent([FromRoute()]
    EventIdDto idDto, [FromQuery()]
    EventUpdateInput eventUpdateDto)
    {
        try
        {
            await _service.UpdateEvent(idDto, eventUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

}
