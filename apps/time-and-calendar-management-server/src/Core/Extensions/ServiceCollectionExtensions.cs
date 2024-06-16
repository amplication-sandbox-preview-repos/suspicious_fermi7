using TimeAndCalendarManagement.APIs;

namespace TimeAndCalendarManagement;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEventsService, EventsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
