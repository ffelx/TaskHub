using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class StudentInfoHeadersFilter : Attribute, IAsyncActionFilter
    {
        private const string HeaderName = "X-Student-Name";
        private const string HeaderGroup = "X-Student-Group";

        private const string StudentName = "Veshnyakov Felix Alexandrovich";
        private const string StudentGroup = "RI-240931";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Response.Headers[HeaderName] = StudentName;
            context.HttpContext.Response.Headers[HeaderGroup] = StudentGroup;
            await next.Invoke();
        }
    }
}
