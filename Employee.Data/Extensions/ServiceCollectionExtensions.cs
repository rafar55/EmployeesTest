using EmployeeChallenge.Application.Common;
using EmployeeChallenge.Application.Employees.Repositories;
using EmployeeChallenge.Application.Employees.Services;
using EmployeeChallenge.Data.Common;
using EmployeeChallenge.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeChallenge.Data.Extensions;
public static class ServiceCollectionExtensions
{
    public static  IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWorkDapper>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        return services;
    }
}

