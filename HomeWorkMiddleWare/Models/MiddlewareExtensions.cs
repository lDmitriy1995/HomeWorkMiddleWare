using HomeWorkMiddleWare.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRequestHeadersMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestHeadersMiddleware>();
    }
}

public class Startup
{
    // ...

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        // ...

        app.UseRequestHeadersMiddleware();

        // ...
    }
}
