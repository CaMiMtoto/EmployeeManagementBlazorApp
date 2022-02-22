using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _appDbContext;

    public EmployeeRepository(AppDbContext appDbContext)
    {
        this._appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await _appDbContext.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployee(int employeeId)
    {
        return (await _appDbContext.Employees
            .Include((x => x.Department))
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId));
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        var result = await _appDbContext.Employees.AddAsync(employee);
        await _appDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Employee?> UpdateEmployee(Employee employee)
    {
        var result = await _appDbContext.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

        if (result == null) return null;
        result.FirstName = employee.FirstName;
        result.LastName = employee.LastName;
        result.Email = employee.Email;
        result.DateOfBirth = employee.DateOfBirth;
        result.Gender = employee.Gender;
        result.DepartmentId = employee.DepartmentId;
        result.PhotoPath = employee.PhotoPath;

        await _appDbContext.SaveChangesAsync();

        return result;
    }

    public async Task DeleteEmployee(int employeeId)
    {
        var result = await _appDbContext.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        if (result != null)
        {
            _appDbContext.Employees.Remove(result);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task<Employee?> GetEmployeeByEmail(string email)
    {
        return await _appDbContext.Employees.FirstOrDefaultAsync(e => e.Email.Equals(email));
    }

    /*
    public Task<IEnumerable<Employee>> Search(string name, Gender? gender)
    {
        throw new NotImplementedException();
    }
    */

    public async Task<IEnumerable<Employee>> Search(string? name, Gender? gender)
    {
        IQueryable<Employee> query = _appDbContext.Employees;

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
        }

        if (gender != null)
        {
            query = query.Where(e => e.Gender == gender);
        }

        return await query.ToListAsync();
    }
}