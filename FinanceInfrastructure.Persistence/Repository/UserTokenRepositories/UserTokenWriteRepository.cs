using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.IUserTokenRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.UserTokenRepositories
{
    public class UserTokenWriteRepository : GenericWriteRepository<UserToken>, IUserTokenWriteRepository
    {
        public UserTokenWriteRepository(FinanceDbContext _financeDbContext) : base(_financeDbContext)
        {
        }
    }
}
