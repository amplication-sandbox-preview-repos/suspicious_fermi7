using Microsoft.EntityFrameworkCore;
using TimeAndCalendarManagement.Infrastructure.Models;

namespace TimeAndCalendarManagement.Infrastructure;

public class TimeAndCalendarManagementDbContext : DbContext
{
    public TimeAndCalendarManagementDbContext(
        DbContextOptions<TimeAndCalendarManagementDbContext> options
    )
        : base(options) { }

    public DbSet<Event> Events { get; set; }

    public DbSet<User> Users { get; set; }
}
