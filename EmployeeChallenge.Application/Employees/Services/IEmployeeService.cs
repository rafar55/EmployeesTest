using EmployeeChallenge.Core.Models;

namespace EmployeeChallenge.Application.Employees.Services;
public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(string searchParam, string sortColumn, bool ascending = true);
}
