using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository
{
    public interface ICommit
    {
        Task CommitAsync();
        void Commit();
    }
}
