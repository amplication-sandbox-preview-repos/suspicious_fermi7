using Microsoft.AspNetCore.Mvc;

namespace TimeAndCalendarManagement.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
