using CPR.API.Data.Interfaces;

namespace CPR.API.Data
{
    public class UnitOfWork(AppDbContext context, IServiceProvider serviceProvider) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private readonly Dictionary<Type, object> _repositories = [];

        public IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (_repositories.TryGetValue(type, out object? value))
            {
                return (IRepository<T>)value;
            }
            var repoInstance = new Repository<T>(_context);
            _repositories[type] = repoInstance;
            return repoInstance;
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
