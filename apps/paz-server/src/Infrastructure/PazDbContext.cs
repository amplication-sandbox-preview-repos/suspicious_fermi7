using Microsoft.EntityFrameworkCore;
using Paz.Infrastructure.Models;

namespace Paz.Infrastructure;

public class PazDbContext : DbContext
{
    public PazDbContext(DbContextOptions<PazDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }
}
