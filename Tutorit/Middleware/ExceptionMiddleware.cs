using Tutorit.Common.Exceptions;

namespace Tutorit.Middleware;


public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            if (ex is NotFoundException exception)
            {
                context.Response.StatusCode = 404;
            }

            if (ex is ForbiddenException exception2)
            {
                context.Response.StatusCode = 403;
            }
            if (ex is ConflictException exception3)
            {
                context.Response.StatusCode = 409;
            }
        }
    }
}