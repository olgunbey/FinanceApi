using FinanceCore.Domain.Command;
using FinanceCore.Repository.IRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository
{
    public class GenericReadRepository<T> : IReadRepository<T> where T : BaseEntityID, new()
    {
        protected FinanceDbContext _FinanceDbContext { get; set; }
        public GenericReadRepository(FinanceDbContext financeDbContext)
        {
            _FinanceDbContext = financeDbContext;
        }
        public async Task<T> FirsOrDefaultAsync(Expression<Func<T, bool>> expression) //null olup olmama kontrolü yapılcak
        {
          return await  _FinanceDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public  Task<IQueryable<T>> GetAllAsync()
        {
            return  Task.FromResult(_FinanceDbContext.Set<T>().AsNoTracking().AsQueryable());
        }

        public async Task<T> GetByID(int id)
        {
            return await _FinanceDbContext.Set<T>().FindAsync(id);
        }

        public Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            return Task.FromResult(_FinanceDbContext.Set<T>().AsNoTracking().Where(expression));
        }

        public Task<bool> HasValueAsync(int _id)
        {
         return Task.FromResult(_FinanceDbContext.Set<T>().Any(x => x.ID == _id));
        }
    }
}
