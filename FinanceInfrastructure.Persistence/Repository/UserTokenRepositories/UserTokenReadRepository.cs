using FinanceCore.Domain.Entities;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.IRepository.IUserTokenRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.UserTokenRepositories
{
    public class UserTokenReadRepository : GenericReadRepository<UserToken>, IUserTokenReadRepository
    {
        public UserTokenReadRepository(FinanceDbContext financeDbContext) : base(financeDbContext)
        {

        }

        public async Task<IQueryable<User>> FirstOrDefaultImplicitLoadingUserAsync(string refreshToken)
        {
            UserToken userToken = await _FinanceDbContext.UserToken.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (userToken == null)
            {
                throw new NoUserException("No user exception");
            }
            return _FinanceDbContext.UserToken.Entry(userToken).Reference(x => x.User).Query();
        }
    }
}
