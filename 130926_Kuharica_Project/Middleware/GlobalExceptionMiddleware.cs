using BusinessLayerLogic.Exceptions;
using System.Diagnostics;

namespace _130926_Kuharica_Project.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);

            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = ex switch { 
                NotFoundException => StatusCodes.Status404NotFound, 
                ConflictException => StatusCodes.Status409Conflict, 
                _ => StatusCodes.Status500InternalServerError
            };

       
            if (statusCode == 500)
            {
                _logger.LogError(ex, "Unexpected error");
            }
            else
            {
                _logger.LogWarning("{Message}", ex.Message);
            }

            var response = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = statusCode == 500 ? "Unexpected error" : ex.Message,
                TraceId = context.TraceIdentifier
            };

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
