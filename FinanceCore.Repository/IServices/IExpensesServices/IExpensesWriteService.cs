using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IServices.IExpensesServices
{
    public interface IExpensesWriteService:IWriteService<Expenses>
    {
        Task<ResponseDto<ExpensesResponseDto>> AddExpenses(Expenses exp);
    }
}
