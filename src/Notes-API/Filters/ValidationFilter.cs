using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Notes_API.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errorsInModelState = context.ModelState
                .Where(x => x.Value is { Errors.Count: > 0 })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray());

            var errorResponse = new List<string>();

            foreach (var error in errorsInModelState)
            {
                if (error.Value != null) errorResponse.AddRange(error.Value);

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }

            await next();
        }

        await next();
    }
}