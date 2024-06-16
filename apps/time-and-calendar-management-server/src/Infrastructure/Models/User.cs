using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeAndCalendarManagement.Infrastructure.Models;

[Table("Users")]
public class User
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    [Required()]
    public string Username { get; set; }

    public string? Email { get; set; }

    [Required()]
    public string Password { get; set; }

    [Required()]
    public string Roles { get; set; }

    [StringLength(1000)]
    public string? Title { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public List<User>? Users { get; set; } = new List<User>();

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; } = null;
}
