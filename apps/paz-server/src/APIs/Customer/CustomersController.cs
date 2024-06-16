using Microsoft.AspNetCore.Mvc;

namespace Paz.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
