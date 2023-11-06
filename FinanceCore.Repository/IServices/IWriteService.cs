using FinanceCore.Domain.Command;
using FinanceCore.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IServices
{
    public interface IWriteService<T>:IWriteRepository<T> where T : BaseEntityID, new()
    {

    }
}
