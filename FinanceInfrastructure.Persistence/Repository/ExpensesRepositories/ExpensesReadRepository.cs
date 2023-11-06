using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.IExpensesRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.ExpensesRepositories
{
    public class ExpensesReadRepository : GenericReadRepository<Expenses>, IExpensesReadRepository
    {
        public ExpensesReadRepository(FinanceDbContext financeDbContext) : base(financeDbContext)
        {
        }
    }
}
