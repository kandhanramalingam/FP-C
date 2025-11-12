using System.Linq.Expressions;

namespace FP_C.API.Data.Interfaces
{
    /// <summary>
    /// Used to submit or retrieve data from db
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Asynchronously retrieves an entity by its unique identifier.
        /// </summary>
        /// <remarks>This method performs an asynchronous operation to fetch an entity by its identifier. 
        /// Ensure that the identifier provided is valid and corresponds to an existing entity.</remarks>
        /// <param name="id">The unique identifier of the entity to retrieve. Must be a positive integer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity of type <typeparamref
        /// name="T"/>  if found; otherwise, <see langword="null"/>.</returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Retrieves all items of type <typeparamref name="T"/> in a paginated format.
        /// </summary>
        /// <remarks>This method supports pagination by allowing the caller to specify the page index and
        /// page size. If no parameters are provided, it retrieves the first page with a default size of 20
        /// items.</remarks>
        /// <param name="page">The zero-based page index to retrieve. Defaults to 0.</param>
        /// <param name="pageSize">The number of items to include in each page. Defaults to 20. Must be greater than 0.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{T}"/>
        /// of items of type <typeparamref name="T"/> for the specified page.</returns>
        IQueryable<T> GetAll(int page = 0, int pageSize = 20);
        /// <summary>
        /// Asynchronously retrieves a collection of entities that match the specified predicate.
        /// </summary>
        /// <remarks>If no entities match the predicate, the returned collection will be empty.  Ensure
        /// that <paramref name="page"/> and <paramref name="pageSize"/> are non-negative  to avoid unexpected
        /// behavior.</remarks>
        /// <param name="predicate">An expression that defines the conditions each entity must satisfy.</param>
        /// <param name="page">The zero-based page index to retrieve. Defaults to 0.</param>
        /// <param name="pageSize">The number of entities to include in each page. Defaults to 20.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an  <see cref="IEnumerable{T}"/>
        /// of entities that match the specified predicate.</returns>
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, int page = 0, int pageSize = 20);
        Task AddAsync(T entity);
        /// <summary>
        /// Removes the specified entity from the collection.
        /// </summary>
        /// <remarks>This method removes the specified entity from the collection. If the entity does not
        /// exist in the collection,  no action is taken. Ensure that the entity is not <see langword="null"/> before
        /// calling this method.</remarks>
        /// <param name="entity">The entity to remove. Cannot be <see langword="null"/>.</param>
        void Remove(T entity);
        /// <summary>
        /// Updates the specified entity in the data store.
        /// </summary>
        /// <remarks>The entity must already exist in the data store. If the entity does not exist, the
        /// behavior is undefined. Ensure that the entity's state is valid and conforms to any constraints required by
        /// the data store.</remarks>
        /// <param name="entity">The entity to update. Must not be <see langword="null"/>.</param>
        void Update(T entity);
    }
}
