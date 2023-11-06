using FinanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository.IUserRepository
{
    public interface IUserReadRepository:IReadRepository<User>
    {
        Task<IQueryable<UserToken>> UserEmailToken(User user);
        Task<User> HasUserEmail(Expression<Func<User,bool>> expression);
    }
}
