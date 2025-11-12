namespace FP_C.API.Services.Interfaces
{
    public interface IMemoryCacheService
    {
        T? Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan? absoluteExpirationRelativeToNow = null);
        void Remove(string key);
        bool TryGet<T>(string key, out T? value);
    }

}
