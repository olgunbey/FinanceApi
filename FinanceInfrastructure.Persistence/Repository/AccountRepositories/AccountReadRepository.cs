using FinanceCore.Domain.Entities;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.IRepository.IAccountRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.AccountRepositories
{
    public class AccountReadRepository : GenericReadRepository<Account>,IAccountReadRepository
    {
        public AccountReadRepository(FinanceDbContext financeDbContext) : base(financeDbContext)
        {
        }

        public async Task<IQueryable<Expenses>> GetExtre(int id)
        {
          Account? account= await _FinanceDbContext.Accounts.FindAsync(id);
            if(account == null) 
            {
                throw new NotAccountException("not account exception!");
            }
           return _FinanceDbContext.Accounts.Entry(account).Collection(x => x.Expenses).Query();
        }

        public async Task<Account> AccountDifExpensesMoney(Expression<Func<Account, bool>> expression)
        {
         return await  _FinanceDbContext.Accounts.Include(y => y.Expenses)
                .FirstOrDefaultAsync(expression);
        }

        public async Task<IQueryable<Account>> HasUserAccountNo(string email)
        {

          User? user= await _FinanceDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if(user==null)
            {
                throw new NoUserException("not user exception");
            }

           return _FinanceDbContext.Users.Entry(user)
                .Collection(x => x.Accounts)
                .Query();
        }
    }
}
