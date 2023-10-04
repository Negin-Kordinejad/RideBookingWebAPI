using RideBooking.Infrastructure.Models;
using System.Text.Json;

namespace RideBookingWebAPI.App_Start
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorResponse = new Response();
            switch (exception)
            {
                case ArgumentException:
                    errorResponse.AddError(ResponseErrorCodeConstants.ArgumentException, exception.Message);
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    errorResponse.AddError(ResponseErrorCodeConstants.UnexpectedError, "Oops! Something went wrong.");
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }
            _logger.LogError(exception, exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
        }
    }
}
