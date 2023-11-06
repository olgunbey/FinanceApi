using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.IExpensesRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FinanceInfrastructure.Persistence.Repository.ExpensesRepositories
{
    public class ExpensesWriteRepository : GenericWriteRepository<Expenses>, IExpensesWriteRepository
    {
        public ExpensesWriteRepository(FinanceDbContext _financeDbContext) : base(_financeDbContext)
        {
        }


        public async Task<IQueryable<Expenses>> AddExpenses(Expenses expenses)
        {
            Account account =await FinanceDbContext.Accounts.FindAsync(expenses.AccountID);
            if (account is null)
            {
                return null;
            }
           return FinanceDbContext.Accounts.Entry(account).Collection(y=>y.Expenses).Query();
           
           
            
        }
    }
}
