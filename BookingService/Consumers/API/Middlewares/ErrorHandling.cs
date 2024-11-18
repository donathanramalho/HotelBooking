using Microsoft.AspNetCore.Diagnostics;

namespace API.Middlewares
{
    public record Error(int Status, string Message, Object? Details = null);

    public class ErrorHandlingMiddleware : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
                HttpContext context,
                Exception exception,
                CancellationToken cancellationToken)
        {
            var error = exception switch
            {
                
                _ => new Error(StatusCodes.Status500InternalServerError, "Unknown server error.")
            };

            context.Response.StatusCode = error.Status;
            await context.Response.WriteAsJsonAsync(error, cancellationToken);

            return true;
        }
    }
}