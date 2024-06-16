using Paz.Infrastructure;

namespace Paz.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(PazDbContext context)
        : base(context) { }
}
