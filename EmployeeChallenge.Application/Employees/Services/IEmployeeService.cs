using EmployeeChallenge.Application.Employees.Dtos;
using EmployeeChallenge.Core.Models;

namespace EmployeeChallenge.Application.Employees.Services;
public interface IEmployeeService
{
    Task<int> AddEmployeeAsync(EditEmployeeDto data);
    Task DeleteAsync(int employeeId);
    Task<Employee> GetByIdAsync(int employeeId);
    Task<IEnumerable<Employee>> GetEmployeesAsync(string searchParam, string sortColumn, bool ascending = true);
    Task UpdateEmployeeAsync(int employeeId, EditEmployeeDto data);
}
