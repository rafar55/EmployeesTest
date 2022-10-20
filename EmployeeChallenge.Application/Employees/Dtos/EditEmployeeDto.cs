using EmployeeChallenge.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeChallenge.Application.Employees.Dtos;
public class EditEmployeeDto
{
    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    [RegularExpression(@"^(\([0-9]{3}\) |[0-9]{3}-)[0-9]{3}-[0-9]{4}$", ErrorMessage = "Invalid Phone Number you must (###) ###-#### or ###-###-####")]
    public string Phone { get; set; }

    [Required]
    public string ZipCode { get; set; }

    [Required]
    public DateTime HireDate { get; set; } = DateTime.Now;

    public Employee MapToDbModel() => new Employee()
    {
        FirstName = FirstName,
        LastName = LastName,
        HireDate = HireDate,
        Phone = Phone,
        ZipCode = ZipCode
    };
}
