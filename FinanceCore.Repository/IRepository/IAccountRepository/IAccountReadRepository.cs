using FinanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository.IAccountRepository
{
    public interface IAccountReadRepository:IReadRepository<Account>
    {
        Task<IQueryable<Account>> HasUserAccountNo(string email);
        Task<IQueryable<Expenses>> GetExtre(int id);

        Task<Account> AccountDifExpensesMoney(Expression<Func<Account, bool>> expression);
    }
}
