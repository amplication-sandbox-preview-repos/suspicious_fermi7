namespace TimeAndCalendarManagement.APIs.Dtos;

public class EventDto : EventIdDto
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
