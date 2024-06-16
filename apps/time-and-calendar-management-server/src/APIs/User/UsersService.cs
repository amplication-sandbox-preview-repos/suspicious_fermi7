using TimeAndCalendarManagement.Infrastructure;

namespace TimeAndCalendarManagement.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(TimeAndCalendarManagementDbContext context)
        : base(context) { }
}
