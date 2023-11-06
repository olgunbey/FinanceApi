using FinanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository.IUserTokenRepository
{
    public interface IUserTokenReadRepository:IReadRepository<UserToken>
    {
        Task<IQueryable<User>> FirstOrDefaultImplicitLoadingUserAsync(string refreshToken);
    }
}
