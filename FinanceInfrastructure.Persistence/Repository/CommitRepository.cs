using FinanceCore.Repository.IRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository
{
    public class CommitRepository : ICommit
    {
        public readonly FinanceDbContext _FinanceDbContext;
        public CommitRepository(FinanceDbContext financeDbContext)
        {
            _FinanceDbContext = financeDbContext;
        }

        public void Commit()
        {
            _FinanceDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _FinanceDbContext.SaveChangesAsync();
        }


    }
}
