using EmployeeManagement.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetEmployees()
    {
        try
        {
            return Ok(await _employeeRepository.GetEmployees());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
        }
    }
}