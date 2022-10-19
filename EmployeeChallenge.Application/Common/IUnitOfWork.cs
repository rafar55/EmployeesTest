using System.Data;

namespace EmployeeChallenge.Application.Common;
public interface IUnitOfWork
{
    IDbConnection Connection { get; }
    void BeginTransaction();
    void RollbackTransaction();
}
