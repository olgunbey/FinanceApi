using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository
{
    public interface IReadRepository<T> where T : class
    {
        Task<T> GetByID(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression);
        Task<T> FirsOrDefaultAsync(Expression<Func<T,bool>> expression);
        Task<bool> HasValueAsync(int id);
    }
}
