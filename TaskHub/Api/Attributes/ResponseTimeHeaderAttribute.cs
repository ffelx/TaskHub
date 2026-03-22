using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Attributes;

public class ResponseTimeHeaderAttribute : Attribute, IAsyncActionFilter
{
    private const string HeaderTime = "X-Response-Time-Ms";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        context.HttpContext.Response.OnStarting(() =>
        {
            stopwatch.Stop();
            context.HttpContext.Response.Headers[HeaderTime] = stopwatch.ElapsedMilliseconds.ToString();
            return Task.CompletedTask;
        });
        await next();
    }
}
