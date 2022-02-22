using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

public class EmployeesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}