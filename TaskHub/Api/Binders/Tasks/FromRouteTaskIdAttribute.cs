using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Binders.Tasks
{
    public class FromRouteTaskIdAttribute : ModelBinderAttribute
    {
        public FromRouteTaskIdAttribute()
        {
            BinderType = typeof(FromRouteTaskIdModelBinder);
            BindingSource = BindingSource.Path;
        }
    }
}
