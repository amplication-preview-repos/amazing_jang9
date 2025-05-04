using Microsoft.AspNetCore.Mvc;

namespace Webapi.APIs;

[ApiController()]
public class EmployeesController : EmployeesControllerBase
{
    public EmployeesController(IEmployeesService service)
        : base(service) { }
}
