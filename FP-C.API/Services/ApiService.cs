using FP_C.API.Services.Interfaces;
using RestSharp;
using System.Net;

namespace FP_C.API.Services
{
    public class ApiService : IApiService
    {
        private readonly IConfiguration _Configuration;
        private IRestClient _Client;

        public ApiService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public virtual async Task<string> ExecuteAsync(string basePath, string function, object payload, string key = "", Dictionary<string, string> headers = null, bool retry = true)
        {
            string content = string.Empty;
            try
            {
                _Client = new RestClient(basePath);
                RestRequest request = new(function.Trim(), Method.Post);
                WebRequest.DefaultWebProxy = null;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                if (!string.IsNullOrEmpty(key))
                {
                    request.AddHeader("Bearer", key);
                }
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> param in headers)
                    {
                        request.AddHeader(param.Key, param.Value);
                    }                        
                }
                if (payload != null)
                {
                    request.AddJsonBody(payload);
                }
                    
                var dateTimeOfRequestSend = DateTime.Now;
                var response = await _Client.ExecuteAsync(request);
                content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                {
                    content = !string.IsNullOrEmpty(response.StatusDescription) ? response.StatusDescription : (!string.IsNullOrEmpty(content) ? content : "Error contacting API");
                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        content = content + "." + response.Content;
                    }
                    if(retry)
                    {
                        return await ExecuteAsync(basePath, function, payload, key, headers, false);
                    }
                    return content;
                }
                else
                {
                    return content;
                }
            }
            catch (Exception ex)
            {
                if(retry)
                {
                    return await ExecuteAsync(basePath, function, payload, key, headers, false);
                }
            }
            return content;
        }
    }
}
