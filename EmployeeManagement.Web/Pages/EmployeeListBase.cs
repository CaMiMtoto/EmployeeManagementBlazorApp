using System.ComponentModel;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages;

public class EmployeeListBase : ComponentBase
{
    [Inject] public IEmployeeService? EmployeeService { get; set; }
    protected IEnumerable<Employee>? Employees { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (EmployeeService != null)
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
    }

   
}