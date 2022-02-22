using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages;

public class EmployeeDetailsBase : ComponentBase
{
    [Parameter]
    public string Id { get; set; }

    public Employee? Employee { get; set; }

    [Inject]
    public IEmployeeService? EmployeeService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        if(EmployeeService !=null)
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

    }
}