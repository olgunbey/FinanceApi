using FinanceCore.Domain.Command;
using FinanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository
{
    public interface IWriteRepository<T> where T : BaseEntityID,new()
    {
        Task<T> AddAsync(T entity);
        Task<IList<T>> AddRangeAsync(IList<T> entities);
        Task<IList<T>> RemoveRangeAsync(IList<T> entities);
        Task<T> RemoveAsync(T entity);
        Task<T> UpdateAsync(T entity);
    } 
}
