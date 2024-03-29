using Microsoft.AspNetCore.Mvc;

namespace Notes_API.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (InvalidOperationException exception)
            {
                var problemDetails = new ProblemDetails
                {
                    Detail = exception.Message
                };

                httpContext.Response.StatusCode =
                    StatusCodes.Status400BadRequest;

                await httpContext.Response.WriteAsJsonAsync(problemDetails);
            }
            catch (Exception exception)
            {
                var problemDetails = new ProblemDetails
                {
                    Detail = exception.Message
                };

                httpContext.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await httpContext.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}