using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.IUserRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinanceInfrastructure.Persistence.Repository.UserRepositories
{
    public class UserReadRepository : GenericReadRepository<User>,IUserReadRepository
    {
        public UserReadRepository(FinanceDbContext financeDbContext) : base(financeDbContext)
        {
        }

        public Task<IQueryable<UserToken>> UserEmailToken(User user)
        {
          return Task.FromResult(_FinanceDbContext.Users.Entry(user).Collection(y=>y.UserTokens).Query());
        }

        public async Task<User> HasUserEmail(Expression<Func<User, bool>> expression)
        {
          return await _FinanceDbContext.Users.FirstOrDefaultAsync(expression);
        }



    }
}
