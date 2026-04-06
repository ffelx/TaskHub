using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Binders.Tasks;

public class FromRouteTaskIdModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var modelName = bindingContext.ModelName;
        var value = bindingContext.ActionContext.RouteData.Values["id"]?.ToString();
        if (string.IsNullOrWhiteSpace(value))
        {
            bindingContext.ModelState.TryAddModelError(modelName, "Идентификатор задачи не задан");
            bindingContext.Result = ModelBindingResult.Failed();
        }
        else if (Guid.TryParse(value, out Guid guid))
        {
            bindingContext.Result = ModelBindingResult.Success(guid);
        }
        else
        {
            bindingContext.ModelState.TryAddModelError(modelName, "Идентификатор задачи имеет некорректный формат");
            bindingContext.Result = ModelBindingResult.Failed();
        }

        return Task.CompletedTask;
    }
}
