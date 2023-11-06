using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IServices.IAccountServices
{
    public interface IAccountReadService:IReadService<Account>
    {
        Task<ResponseDto<List<ExtreDto>>> GetExtre(int id);
        Task AccountTransferMoney(MoneyTransferDto moneyTransferDto);
    }
}
