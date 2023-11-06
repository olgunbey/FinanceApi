using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceCore.Repository.Dtos;

namespace FinanceCore.Repository.IServices.IUserServices
{
    public interface IUserReadService:IReadRepository<User>
    {
        Task<ResponseDto<User>> HasUserEmail(string email, string password);
    }
}
