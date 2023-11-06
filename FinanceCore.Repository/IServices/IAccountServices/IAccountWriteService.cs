using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IServices.IAccountServices
{
    public interface IAccountWriteService:IWriteService<Account>
    {
        Task<ResponseDto<AccountDto>> AddAcountAsnyc(AccountDto account);
    }
}
