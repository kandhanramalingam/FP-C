using FP_C.API.Data.Interfaces;
using FP_C.API.Services.Interfaces;
using System.Linq.Expressions;

namespace FP_C.API.Services
{
    public abstract class BaseService<T>(IUnitOfWork unitOfWork) : IBaseService<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; } = unitOfWork;
        public IRepository<T> Repository => UnitOfWork.GetRepository<T>();

        public async virtual Task AddAsync(T entity)
        {
            await Repository.AddAsync(entity);
            await UnitOfWork.CompleteAsync();
        }

        public async virtual Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, int page = 0, int size = 20)
        {
            return Repository.Find(predicate, page, size);
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync(int page = 0, int size = 20)
        {
            return Repository.GetAll(page, size);
        }

        public async virtual Task RemoveAsync(T entity)
        {
            await Task.Run(() => Repository.Remove(entity));
            await UnitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Repository.Update(entity));
            await UnitOfWork.CompleteAsync();
        }
    }
}
