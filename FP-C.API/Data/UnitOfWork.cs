using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FP_C.API.Data
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

        public async Task<Result> CompleteAsync()
        {
            try
            {
                var changes = await _context.SaveChangesAsync();
                return changes > 0 ? Result.Ok("Changes saved successfully.") : Result.Fail("No changes were made to the database.");
            }
            catch (DbUpdateException ex)
            {
                return Result.Fail($"Database update failed. See inner exception for details.{ex.Message}");
            }
            catch (ValidationException ex)
            {
                return Result.Fail($"Database update failed. See inner exception for details.{ex.Message}");
            }
            catch (Exception ex)
            {
                return Result.Fail($"Database update failed. See inner exception for details.{ex.Message}");
            }
        }

        public void Dispose() => _context.Dispose();
    }
}
