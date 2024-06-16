using TimeAndCalendarManagement.APIs.Dtos;
using TimeAndCalendarManagement.Infrastructure.Models;

namespace TimeAndCalendarManagement.APIs.Extensions;

public static class EventsExtensions
{
    public static EventDto ToDto(this Event model)
    {
        return new EventDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,

        };
    }

    public static Event ToModel(this EventUpdateInput updateDto, EventIdDto idDto)
    {
        var event = new Event { 
               Id = idDto.Id
};

     // map required fields
     if(updateDto.CreatedAt != null) {
     event.CreatedAt = updateDto.CreatedAt.Value;
}
if(updateDto.UpdatedAt != null) {
     event.UpdatedAt = updateDto.UpdatedAt.Value;
}

    return event; }

}
