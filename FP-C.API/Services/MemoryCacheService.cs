using FP_C.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FP_C.API.Services
{
    public class MemoryCacheService(IMemoryCache cache) : IMemoryCacheService
    {
        private readonly IMemoryCache _cache = cache;

        public T? Get<T>(string key)
        {
            return _cache.TryGetValue(key, out T? value) ? value : default;
        }

        public bool TryGet<T>(string key, out T? value)
        {
            if (_cache.TryGetValue(key, out var result) && result is T casted)
            {
                value = casted;
                return true;
            }

            value = default;
            return false;
        }

        public void Set<T>(string key, T value, TimeSpan? absoluteExpirationRelativeToNow = null)
        {
            var options = new MemoryCacheEntryOptions();

            if (absoluteExpirationRelativeToNow.HasValue)
                options.AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;

            _cache.Set(key, value, options);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
