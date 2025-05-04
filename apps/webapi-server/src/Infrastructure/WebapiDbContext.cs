using Microsoft.EntityFrameworkCore;
using Webapi.Infrastructure.Models;

namespace Webapi.Infrastructure;

public class WebapiDbContext : DbContext
{
    public WebapiDbContext(DbContextOptions<WebapiDbContext> options)
        : base(options) { }

    public DbSet<EmployeeDbModel> Employees { get; set; }
}
