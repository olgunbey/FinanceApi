using FinanceCore.Domain.Command;
using FinanceCore.Domain.Exceptions;
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
    public class GenericWriteRepository<T> : IWriteRepository<T> where T : BaseEntityID, new()
    {
        protected FinanceDbContext FinanceDbContext { get; set; }
        public GenericWriteRepository(FinanceDbContext _financeDbContext)
        {
            FinanceDbContext = _financeDbContext;
        }

      
        public async Task<T> AddAsync(T entity)
        {
            await FinanceDbContext.AddAsync(entity);
            await FinanceDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<T>> AddRangeAsync(IList<T> entities)
        {
            await FinanceDbContext.AddRangeAsync(entities);
            await FinanceDbContext.SaveChangesAsync();
            return entities;
        }
     
        public async Task<T> RemoveAsync(T entity)
        {
            FinanceDbContext.Remove(entity);
            await  FinanceDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
           FinanceDbContext.Update(entity);
           await FinanceDbContext.SaveChangesAsync();
            return entity;
        }


        public async Task<IList<T>> RemoveRangeAsync(IList<T> entities)
        {
            FinanceDbContext.RemoveRange(entities);
            await FinanceDbContext.SaveChangesAsync();
            return entities;
        }

 

         
    }
}
