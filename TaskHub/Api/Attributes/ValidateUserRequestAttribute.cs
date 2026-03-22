using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class ValidateUserRequestAttribute : Attribute, IAsyncActionFilter
{
    private const string PropertyName = "Name";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var request = context.ActionArguments.Values
            .FirstOrDefault(v => v != null && v.GetType().GetProperty(PropertyName) != null);
        if (request == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }
        var nameProperty = request.GetType().GetProperty(PropertyName);
        var value = nameProperty?.GetValue(request) as string;
        if (string.IsNullOrWhiteSpace(value))
        {
            context.Result = new BadRequestObjectResult("Имя пользователя не задано");
            return;
        }
        await next();
    }
}
