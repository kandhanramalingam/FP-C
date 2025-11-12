using FP_C.API.Data.Interfaces;
using System.Linq.Expressions;

namespace FP_C.API.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        IRepository<T> Repository { get; }
        IUnitOfWork UnitOfWork { get; }
        Task<IEnumerable<T>> GetAllAsync(int page = 0, int size = 20);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, int page = 0, int size = 20);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
