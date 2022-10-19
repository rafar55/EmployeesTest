using EmployeeChallenge.Core.Models;

namespace EmployeeChallenge.Application.Employees.Repositories;
public interface IEmployeeRepository
{
    Task<int> AddEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int employeeId);
    Task<Employee> GetByIdAsync(int employeeId);
    Task<IEnumerable<Employee>> GetEmployeesAsync(string searchParam, string sortColumn, bool ascending = true);
    Task UpdateEmployeeAsync(Employee employee);
}
