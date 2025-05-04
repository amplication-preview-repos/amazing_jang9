using Microsoft.AspNetCore.Mvc;
using Webapi.APIs.Common;
using Webapi.Infrastructure.Models;

namespace Webapi.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class EmployeeFindManyArgs : FindManyInput<Employee, EmployeeWhereInput> { }
