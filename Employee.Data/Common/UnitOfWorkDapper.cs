using EmployeeChallenge.Application.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeChallenge.Data.Common;
public class UnitOfWorkDapper : IUnitOfWork, IDisposable
{
    private IDbConnection _cnn;
    private IDbTransaction? _tx;
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWorkDapper(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        _serviceProvider = serviceProvider;
    }

    public IDbConnection Connection => _cnn;
    public IDbTransaction? Transaction => _tx;


    public TRepository GetRepository<TRepository>()
        where TRepository : class
    {
        return _serviceProvider.GetRequiredService<TRepository>();
    }

    public void BeginTransaction() => _tx ??= _cnn.BeginTransaction();
    
    public void RollbackTransaction()
    {
        _tx?.Rollback();
        _tx?.Dispose();
        _tx = null;
    }

    public void Dispose()
    {
        _tx?.Dispose();
        _cnn.Close();
    }

}
