using FinanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository.IAccountRepository
{
    public interface IAccountWriteRepository:IWriteRepository<Account>
    {
        Task<IQueryable<Account>> AddAccountAsync(Account account);
    }
}
