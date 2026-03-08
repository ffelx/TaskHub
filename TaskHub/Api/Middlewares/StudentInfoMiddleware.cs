namespace Api.Middlewares
{
    public class StudentInfoMiddleware
    {
        private readonly RequestDelegate _next;

        private const string HeaderName = "X-Student-Name";
        private const string HeaderGroup = "X-Student-Group";

        private const string StudentName = "Veshnyakov Felix Alexandrovich";
        private const string StudentGroup = "RI-240931";

        public StudentInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers[HeaderName] = StudentName;
            context.Response.Headers[HeaderGroup] = StudentGroup;
            await _next.Invoke(context);
        }
    }
}
