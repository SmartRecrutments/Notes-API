using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;
using Logic.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using Notes_API.Session;

namespace Notes_API.Middlewares;

public class BasicAuthMiddleware(RequestDelegate next, IUserSession userSession)
{
    public async Task Invoke(HttpContext context, IUserService userService)
    {
        try
        {
            if (!StringValues.IsNullOrEmpty(context.Request.Headers.Authorization))
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers.Authorization!);
                if (authHeader.Parameter != null)
                {
                    var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                    var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                    var username = credentials[0];
                    var password = credentials[1];

                    var authenticatedUser = await userService.Authenticate(username, password);

                    if (authenticatedUser == null)
                    {
                        context.Response.StatusCode = 403;
                        await next(context);
                    }

                    context.Items["User"] = authenticatedUser;
                    userSession.LogInUser(authenticatedUser ??
                                          throw new ArgumentNullException($"Authenticated user can't be null"));
                }
            }
        }
        catch (Exception ex)
        {
            throw new AuthenticationFailureException("Authentication failed", ex);
        }

        await next(context);
    }
}