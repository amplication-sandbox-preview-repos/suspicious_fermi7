using TimeAndCalendarManagement.Infrastructure;

namespace TimeAndCalendarManagement.APIs;

public class EventsService : EventsServiceBase
{
    public EventsService(TimeAndCalendarManagementDbContext context)
        : base(context) { }
}
