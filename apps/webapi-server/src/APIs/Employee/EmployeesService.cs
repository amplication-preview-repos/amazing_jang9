using Webapi.Infrastructure;

namespace Webapi.APIs;

public class EmployeesService : EmployeesServiceBase
{
    public EmployeesService(WebapiDbContext context)
        : base(context) { }
}
