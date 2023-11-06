using FinanceCore.Domain.Command;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IServices;


namespace FinanceApi.Services
{
    public class GenericWriteService<T> : IWriteService<T> where T : BaseEntityID, new()
    {
        protected readonly IWriteRepository<T> _genericWriteRepository;
        public GenericWriteService(IWriteRepository<T> genericWriteRepository)
        {
            _genericWriteRepository = genericWriteRepository;
        }

        public async Task<T> AddAsync(T entity)
        {
            
            try
            {
                return await _genericWriteRepository.AddAsync(entity);


            }
            catch (Exception e)
            {

                throw new WriteException($"{typeof(T)} An error occurred while added! "+e.Message);
            }

           
        }

        public async Task<IList<T>> AddRangeAsync(IList<T> entities)
        {
            try
            {
             return await _genericWriteRepository.AddRangeAsync(entities);
            }
            catch (Exception e )
            {

                throw new WriteException($"{typeof(T)} An error occurred while addRange! " + e.Message);
            }
        }

        public async Task<T> RemoveAsync(T entity)
        {
            try
            {
              return await  _genericWriteRepository.RemoveAsync(entity);
            }
            catch (Exception e )
            {

                throw new WriteException($"{nameof(T)} An error occurred while remove! " + e.Message);
            }
        }

        public async Task<IList<T>> RemoveRangeAsync(IList<T> entities)
        {
            try
            {
              return await  _genericWriteRepository.RemoveRangeAsync(entities);
            }
            catch (Exception e)
            {

                throw new WriteException($"{nameof(T)} An error occurred while removeRange! " + e.Message);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                return await _genericWriteRepository.UpdateAsync(entity);
            }
            catch (Exception e )
            {
                throw new WriteException($"{nameof(T)} An error occurred while update! " + e.Message);
            }
        }
    }
}
