using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Domain.Services;

namespace Evolve_Store.Helpers
{
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSeconds;
        public CachedAttribute(int timeToLiveSeconds)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // get the services from IResponcecasheservie and detremine if the response is cached or not
            var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<IResponcecasheservie>(); 
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = await cacheSettings.Getcacheresponce(cacheKey);
            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult()
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            // if not cached, we need to execute the controller to get the data and cache it
            var executedContext = await next.Invoke(); 
            if (executedContext.Result is OkObjectResult result)
            {
                await cacheSettings.CasheResponceAsync(cacheKey, result.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));
            }
        }


        // generate unique key for each request
        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append(request.Path); // add the path of endpoint to the key
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
