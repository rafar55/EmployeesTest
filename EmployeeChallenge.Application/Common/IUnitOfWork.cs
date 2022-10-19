using System.Data;

namespace EmployeeChallenge.Application.Common;
public interface IUnitOfWork
{
    IDbConnection Connection { get; }
    IDbTransaction? Transaction { get; }

    void BeginTransaction();
    TRepository GetRepository<TRepository>() where TRepository : class;
    void RollbackTransaction();
}
