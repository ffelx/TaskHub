using System.Diagnostics;

namespace Api.Middlewares
{
    public class ResponseTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HeaderTime = "X-Response-Time-Ms";

        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            context.Response.OnStarting(() =>
            {
                stopwatch.Stop();
                context.Response.Headers[HeaderTime] = stopwatch.ElapsedMilliseconds.ToString();
                return Task.CompletedTask;
            });
            await _next.Invoke(context);
        }
    }
}
