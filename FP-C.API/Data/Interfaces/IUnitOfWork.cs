using FP_C.API.Models;

namespace FP_C.API.Data.Interfaces
{
    /// <summary>
    /// Unit of work is wrap db calls into 1
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Retrieves a spesific repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> GetRepository<T>() where T : class;
        /// <summary>
        /// Completes the trasaction
        /// </summary>
        /// <returns></returns>
        Task<Result> CompleteAsync();
    }
}
