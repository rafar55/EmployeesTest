using EmployeeChallenge.Application.Common;
using EmployeeChallenge.Application.Employees.Repositories;
using EmployeeChallenge.Core.Models;

namespace EmployeeChallenge.Application.Employees.Services;
public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        var repository = _unitOfWork.GetRepository<IEmployeeRepository>();
        return await repository.GetEmployeesAsync();
    }    
}
