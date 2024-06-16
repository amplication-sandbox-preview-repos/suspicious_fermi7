namespace TimeAndCalendarManagement.APIs.Dtos;

public class UserUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Roles { get; set; }

    public string? Title { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Description { get; set; }

    public List<UserIdDto>? Users { get; set; }

    public UserIdDto? User { get; set; }
}
