using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models;

public class Employee
{
    [Key] public int EmployeeId { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public DateTime DateOfBirth { get; set; }

    [Required] public Gender Gender { get; set; }

    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public string? PhotoPath { get; set; }
}