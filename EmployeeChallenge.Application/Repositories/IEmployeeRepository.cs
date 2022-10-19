using EmployeeChallenge.Core.Models;

namespace EmployeeChallenge.Application.Repositories;
public interface IEmployeeRepository
{
    Task<int> AddEmployeeAsync(Employee employee);    
    Task DeleteEmployeeAsync(int employeeId);
    Task<Employee> GetByIdAsync(int employeeId);
    Task UpdateEmployeeAsync(Employee employee);
}
