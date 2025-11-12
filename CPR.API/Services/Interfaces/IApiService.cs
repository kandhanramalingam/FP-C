namespace CPR.API.Services.Interfaces
{
    public interface IApiService
    {
        Task<string> ExecuteAsync(string basePath, string function, object payload, string key = "", Dictionary<string, string> headers = null, bool retry = true);
    }
}
