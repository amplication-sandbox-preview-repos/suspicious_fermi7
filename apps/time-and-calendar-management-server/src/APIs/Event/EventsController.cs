using Microsoft.AspNetCore.Mvc;

namespace TimeAndCalendarManagement.APIs;

[ApiController()]
public class EventsController : EventsControllerBase
{
    public EventsController(IEventsService service)
        : base(service) { }
}
