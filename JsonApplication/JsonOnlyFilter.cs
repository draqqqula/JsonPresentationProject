using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace JsonApplication
{
    public class JsonOnlyFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.ContentType?.ToLowerInvariant() != "application/json")
            {
                context.Result = new BadRequestObjectResult("Требуется заголовок Content-Type: application/json.");
                return;
            }

            await next();
        }
    }
}
