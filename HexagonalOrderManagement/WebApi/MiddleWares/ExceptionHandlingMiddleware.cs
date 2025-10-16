using Core.Application.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace WebApi.MiddleWares;


// Middleware to handle exceptions globally and return appropriate HTTP responses.
// Will Use it (before) app.MapControllers():
public class ExceptionHandlingMiddleware
{

    private readonly RequestDelegate _next;
    public ExceptionHandlingMiddleware(RequestDelegate next)
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
            await HandlingExceptionAsync(context, ex);
        }
    }




    private static async Task HandlingExceptionAsync(HttpContext context , Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            DomainException => StatusCodes.Status400BadRequest,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };

        var response = new
        {
            status = context.Response.StatusCode,
            error = exception.GetType().Name, //DomainException , NotFoundException etc.
            message = exception.Message
        };

        await context.Response.WriteAsJsonAsync(response);
    }
}
