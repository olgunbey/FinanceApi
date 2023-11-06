using FinanceCore.Domain.Command;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IServices;
using System.Linq.Expressions;


namespace FinanceApi.Services
{
    public class GenericReadService<T> : IReadService<T> where T : BaseEntityID, new()
    {
        public IReadRepository<T> _Repository;
        public GenericReadService(IReadRepository<T> repository)
        {
            _Repository = repository;
        }
        public async Task<T> FirsOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
          T hasEntity=await _Repository.FirsOrDefaultAsync(expression);
            return hasEntity != null ? hasEntity : throw new EmptyEntity("Empty FirstOrDefault");
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
          var GetAllData= (await _Repository.GetAllAsync());
          int Count=GetAllData.ToList().Count;
            return Count == 0 ? throw new EmptyEntity("Empty GetAll") : GetAllData;
        }

        public async Task<T> GetByID(int id)
        {
          T hasEntity=await _Repository.GetByID(id);
            return hasEntity != null ? hasEntity : throw new EmptyEntity($"{nameof(T)}this id does not exist");
        }

        public async Task<bool> HasValueAsync(int id)
        {
         bool hasEntity= await _Repository.HasValueAsync(id);

           return hasEntity = hasEntity ? hasEntity : throw new EmptyEntity("NotEntity");
        }

        public async Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
          var IQueryable= await _Repository.WhereAsync(expression);
          return IQueryable.ToList().Count==0 ? throw new EmptyEntity(""):IQueryable;
        }
    }
}
