using EmployeeChallenge.Application.Common;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeChallenge.Data.Common;
public class UnitOfWorkDapper : IUnitOfWork, IDisposable
{
    private IDbConnection _cnn;
    private IDbTransaction? _tx;

    public UnitOfWorkDapper(string connectionString)
    {
        _cnn = new SqlConnection(connectionString);
    }

    public IDbConnection Connection => _cnn;

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
