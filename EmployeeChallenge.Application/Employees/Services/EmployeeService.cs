using EmployeeChallenge.Application.Common;
using EmployeeChallenge.Application.Employees.Dtos;
using EmployeeChallenge.Application.Employees.Repositories;
using EmployeeChallenge.Core.Models;
using System.Reflection;

namespace EmployeeChallenge.Application.Employees.Services;
public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync(string searchParam, string sortColumn, bool ascending = true)
    {
        var repository = _unitOfWork.GetRepository<IEmployeeRepository>();
        return await repository.GetEmployeesAsync(searchParam, sortColumn, ascending);
    }

    public async Task<Employee> GetByIdAsync(int employeeId)
    {
        var repository = _unitOfWork.GetRepository<IEmployeeRepository>();
        return await repository.GetByIdAsync(employeeId);
    }

    public async Task DeleteAsync(int employeeId)
    {
        var repository = _unitOfWork.GetRepository<IEmployeeRepository>();
        await repository.DeleteEmployeeAsync(employeeId);
    }

    public async Task<int> AddEmployeeAsync(EditEmployeeDto data)
    {
        var repository = _unitOfWork.GetRepository<IEmployeeRepository>();
        var dbModel = data.MapToDbModel();
        StandardizedToE164PhoneNumber(dbModel);
        return await repository.AddEmployeeAsync(dbModel);
    }

    public async Task UpdateEmployeeAsync(int employeeId ,EditEmployeeDto data)
    {
        var repository = _unitOfWork.GetRepository<IEmployeeRepository>();
        var dbModel = data.MapToDbModel();
        StandardizedToE164PhoneNumber(dbModel);
        dbModel.Id = employeeId;
        await repository.UpdateEmployeeAsync(dbModel);
    }

    private void StandardizedToE164PhoneNumber(Employee employee)
    {
        var phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
        var parsedPhone = phoneUtil.Parse(employee.Phone, "US");
        var e164StandardPhone = phoneUtil.Format(parsedPhone, PhoneNumbers.PhoneNumberFormat.E164);
        employee.Phone = e164StandardPhone;
    }

}
