namespace TimeAndCalendarManagement.APIs.Dtos;

public class EventCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
