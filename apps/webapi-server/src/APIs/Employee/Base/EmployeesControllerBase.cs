using Microsoft.AspNetCore.Mvc;
using Webapi.APIs;
using Webapi.APIs.Common;
using Webapi.APIs.Dtos;
using Webapi.APIs.Errors;

namespace Webapi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EmployeesControllerBase : ControllerBase
{
    protected readonly IEmployeesService _service;

    public EmployeesControllerBase(IEmployeesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one employee
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Employee>> CreateEmployee(EmployeeCreateInput input)
    {
        var employee = await _service.CreateEmployee(input);

        return CreatedAtAction(nameof(Employee), new { id = employee.Id }, employee);
    }

    /// <summary>
    /// Delete one employee
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEmployee([FromRoute()] EmployeeWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteEmployee(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many employees
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Employee>>> Employees(
        [FromQuery()] EmployeeFindManyArgs filter
    )
    {
        return Ok(await _service.Employees(filter));
    }

    /// <summary>
    /// Meta data about employee records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EmployeesMeta(
        [FromQuery()] EmployeeFindManyArgs filter
    )
    {
        return Ok(await _service.EmployeesMeta(filter));
    }

    /// <summary>
    /// Get one employee
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Employee>> Employee(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Employee(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one employee
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEmployee(
        [FromRoute()] EmployeeWhereUniqueInput uniqueId,
        [FromQuery()] EmployeeUpdateInput employeeUpdateDto
    )
    {
        try
        {
            await _service.UpdateEmployee(uniqueId, employeeUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
