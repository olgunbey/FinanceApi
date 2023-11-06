using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FinanceInfrastructure.Persistence.Interceptors;

public class SaveChangesInterceptor:IDbCommandInterceptor
{
    public ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (command.CommandText.Contains("INSERT INTO [AccountMoneyTransferLog]")) //accountMoneytransferlog'a gidip eklenecek datetime'ye o zamanı yazar
        {
            command.Parameters[0].Value = DateTime.UtcNow;
        }
        return ValueTask.FromResult(result);
    }

    public int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (command.CommandText.Contains("INSERT INTO [AccountMoneyTransferLog]")) //accountMoneytransferlog'a gidip eklenecek datetime'ye o zamanı yazar
        {
            command.Parameters[0].Value = DateTime.UtcNow;
        }
        return ValueTask.FromResult(result);
    }
}