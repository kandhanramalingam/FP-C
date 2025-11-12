using FP_C.API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FP_C.API.Data
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> GetAll(int page = 0, int pageSize = 20)
        {
            return _dbSet
                .OrderBy(x => x)
                .Skip(page * pageSize)
                .Take(pageSize)
                .AsQueryable();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, int page = 0, int pageSize = 20)
        {
            return _dbSet
                .Where(predicate)
                .OrderBy(x => x)
                .Skip(page * pageSize)
                .Take(pageSize)
                .AsQueryable();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
