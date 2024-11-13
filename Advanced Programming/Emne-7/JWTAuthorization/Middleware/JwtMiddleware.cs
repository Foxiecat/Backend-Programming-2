using JWTAuthorization.Services.Interfaces;

namespace JWTAuthorization.Middleware;

public class JwtMiddleware(ITokenService tokenService) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        string? token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

        if (token is not null)
        {
            (string? userId, IEnumerable<string> roles) = tokenService.ValidateAccessToken(token);
            context.Items["UserId"] = userId;
            context.Items["Roles"] = roles;
        }
        
        await next(context);
    }
}