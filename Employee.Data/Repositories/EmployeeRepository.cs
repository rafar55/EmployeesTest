﻿using Dapper;
using EmployeeChallenge.Application.Common;
using EmployeeChallenge.Application.Employees.Repositories;
using EmployeeChallenge.Core.Models;

namespace EmployeeChallenge.Data.Repositories;

public class EmployeeRepository: IEmployeeRepository
{
	private readonly IUnitOfWork _db;

	public EmployeeRepository(IUnitOfWork unitOfWork)
	{
		_db = unitOfWork;
	}

	public async Task<int> AddEmployeeAsync(Employee employee)
	{
		var sql = @"INSERT INTO Employees (FirstName, LastName, Phone, ZipCode, HireDate)
					OUTPUT INSERTED.Id
					Values (@FirstName,@LastName,@Phone,@ZipCode,@HireDate)";
		return await _db.Connection.ExecuteScalarAsync<int>(sql, employee, _db.Transaction);
	}

	public async Task UpdateEmployeeAsync(Employee employee)
	{
		var sql = @"UPDATE Employees 
					SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, ZipCode = @ZipCode, HireDate = @HireDate 
					WHERE Id = @Id";
		await _db.Connection.ExecuteAsync(sql, employee, _db.Transaction);
	}

	public async Task DeleteEmployeeAsync(int employeeId)
	{
		var sql = @"DELETE FROM Employees WHERE Id = @employeeId";
		await _db.Connection.ExecuteAsync(sql, new {employeeId}, _db.Transaction);
	}

	public async Task<Employee> GetByIdAsync(int employeeId)
	{
		var sql = @"Select * FROM Employees WHERE Id = @employeeId";
		return await _db.Connection.QuerySingleOrDefaultAsync<Employee>(sql, new {employeeId}, _db.Transaction);
	}

    public async Task<IEnumerable<Employee>> GetEmployeesAsync(string searchParam, string sortColumn, bool ascending = true)
    {
		var accendingStr = ascending ? "Asc" : "Desc" ;
		var sql = @$"Select * FROM Employees 
					WHERE ((FirstName + ' ' + LastName) LIKE  CONCAT('%',@searchParam,'%') OR Phone LIKE CONCAT('%',@searchParam,'%'))
					ORDER BY CASE			
								WHEN @sortColumn = 'CreatedAt' THEN CONVERT(varchar(50), HireDate)
								WHEN @sortColumn = 'HireDate' THEN CONVERT(varchar(50), HireDate)
								ELSE (FirstName + ' ' + LastName)
							 END {accendingStr}";
        
		return await _db.Connection.QueryAsync<Employee>(sql, new {searchParam, sortColumn}, transaction: _db.Transaction);
    }
}
