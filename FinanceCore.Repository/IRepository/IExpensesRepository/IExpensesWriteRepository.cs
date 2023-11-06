using FinanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository.IExpensesRepository
{
    public interface IExpensesWriteRepository:IWriteRepository<Expenses>
    {
        Task<IQueryable<Expenses>> AddExpenses(Expenses expenses);
    }
}
