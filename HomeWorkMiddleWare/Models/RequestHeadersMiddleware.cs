using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HomeWorkMiddleWare.Models

{
    public class RequestHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestHeadersMiddleware> _logger;
        private static int _requestCount = 0;

        public RequestHeadersMiddleware(RequestDelegate next, ILogger<RequestHeadersMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _requestCount++;
            _logger.LogInformation($"Request #{_requestCount}:");
            foreach (var header in context.Request.Headers)
            {
                _logger.LogInformation($"{header.Key}: {header.Value}");
            }

            await _next(context);
        } 
    }
}
