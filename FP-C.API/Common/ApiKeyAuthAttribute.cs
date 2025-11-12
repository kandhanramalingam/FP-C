using FP_C.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace FP_C.API.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        #region Fields

        private const string ApiKeyHeaderName = "api_key";
        private List<string> _excludeRoutes = new();
        #endregion Fields

        #region Methods

        public ApiKeyAuthAttribute()
        {
            _excludeRoutes = [];
        }
        public ApiKeyAuthAttribute(params string[] excludeRouteName)
        {
            _excludeRoutes = [.. excludeRouteName];
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cache = context.HttpContext.RequestServices.GetRequiredService<IMemoryCacheService>();
            var canExclude = false;
            var apiKeys = MyCommon.GetApiKeys();

            try
            {
                if (_excludeRoutes.Count > 0)
                {
                    canExclude = context.HttpContext.Request.Path.HasValue && _excludeRoutes.Any(x => x.ToLower() == context.HttpContext.Request.Path.Value.ToLower());
                }

            }
            catch { }

            if (!context.HttpContext.Request.Query.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                if (!canExclude)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

            }
            if (!apiKeys.Any(x => x.Accesskey == potentialApiKey) && !canExclude)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }

        #endregion Methods
    }
}
