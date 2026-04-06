using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics;

namespace Api.Filters;

public class RequestLoggingFilter : IAsyncActionFilter
{
    private readonly ILogger<RequestLoggingFilter> _logger;

    public RequestLoggingFilter(ILogger<RequestLoggingFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var method = context.HttpContext.Request.Method;
        var path = context.HttpContext.Request.Path;
        Stopwatch stopwatch = Stopwatch.StartNew();
        _logger.LogInformation("Начало выполнения: {Method} {Path}", method, path);
        var executedContext = await next();
        stopwatch.Stop();

        var statusCode = 200;
        if (executedContext.Result is IStatusCodeActionResult statusCodeResult
            && statusCodeResult.StatusCode.HasValue)
        {
            statusCode = statusCodeResult.StatusCode.Value;
        }
        else if (executedContext.Exception != null)
        {
            statusCode = 500;
        }

        _logger.LogInformation("Конец выполнения: {StatusCode} {Time}", statusCode, stopwatch.ElapsedMilliseconds);
    }
}
