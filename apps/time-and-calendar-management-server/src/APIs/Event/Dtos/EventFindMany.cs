using Microsoft.AspNetCore.Mvc;
using TimeAndCalendarManagement.APIs.Common;
using TimeAndCalendarManagement.Infrastructure.Models;

namespace TimeAndCalendarManagement.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class EventFindMany : FindManyInput<Event, EventWhereInput> { }
