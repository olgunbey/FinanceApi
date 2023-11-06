using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IServices.IExpensesServices;

namespace FinanceApi.Services.ExpensesServices
{
    public class ExpensesReadService : GenericReadService<Expenses>, IExpensesReadService
    {
        public ExpensesReadService(IReadRepository<Expenses> repository) : base(repository)
        {
        }
    }
}
