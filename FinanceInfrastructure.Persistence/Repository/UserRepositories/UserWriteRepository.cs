using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.IUserRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.UserRepositories
{
    public class UserWriteRepository : GenericWriteRepository<User>,IUserWriteRepository
    {
        public UserWriteRepository(FinanceDbContext _financeDbContext) : base(_financeDbContext)
        {
        }
    }
}
