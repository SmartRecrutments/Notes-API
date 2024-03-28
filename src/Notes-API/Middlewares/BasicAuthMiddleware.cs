namespace Notes_API.Middlewares;

using Logic.Interfaces;
using Notes_API.Session;
using System.Net.Http.Headers;
using System.Text;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IUserSession _userSession;

    public BasicAuthMiddleware(RequestDelegate next, IUserSession userSession)
    {
        _next = next;
        _userSession = userSession;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers.Authorization);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
            var username = credentials[0];
            var password = credentials[1];

            var authenticatedUser = await userService.Authenticate(username, password);

            context.Items["User"] = authenticatedUser;
            _userSession.LogInUser(authenticatedUser ?? throw new ArgumentNullException("Authnticated user can't be null"));
        }
        catch
        {
        }

        await _next(context);
    }
}