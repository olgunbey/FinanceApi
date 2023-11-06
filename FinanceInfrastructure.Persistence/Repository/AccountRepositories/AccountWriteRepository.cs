using FinanceCore.Domain.Entities;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository.IAccountRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.AccountRepositories
{
    public class AccountWriteRepository : GenericWriteRepository<Account>, IAccountWriteRepository
    {
        public AccountWriteRepository(FinanceDbContext _financeDbContext) : base(_financeDbContext)
        {
        }

        public async Task<IQueryable<Account>> AddAccountAsync(Account account)
        {
         User user= await FinanceDbContext.Users.FindAsync(account.UserID);
            if (user == null)
            {
                throw new NoUserException("No user exception");
            }
           return FinanceDbContext.Users.Entry(user).Collection(x=>x.Accounts)
                .Query(); //burada user'ın karşısındaki account ıqueryable seviyesinde dönecek
        }
    }
}
