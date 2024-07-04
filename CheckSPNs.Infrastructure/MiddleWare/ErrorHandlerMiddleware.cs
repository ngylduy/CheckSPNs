using CheckSPNs.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CheckSPNs.Infrastructure.MiddleWare
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            var response = new
            {
                succeeded = false,
                status = statusCode,
                title = GetTitle(exception),
                detail = exception.Message,
                errors = GetErrors(exception)
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));

        }

        private static int GetStatusCode(Exception exception) => exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            FormatException => StatusCodes.Status422UnprocessableEntity,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            //ValidationException => StatusCodes.Status422UnprocessableEntity,
            KeyNotFoundException => StatusCodes.Status404NotFound,
            DbUpdateException => StatusCodes.Status400BadRequest,
            Exception e => e.GetType().ToString() == "ApiException" ? StatusCodes.Status400BadRequest
                                                        : StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                DomainException application => application.Title,
                _ => "Server Error"
            };

        public static IReadOnlyCollection<Infrastructure.Exceptions.ValidationError> GetErrors(Exception exception)
        {
            IReadOnlyCollection<Infrastructure.Exceptions.ValidationError> errors = null;
            if (exception is Infrastructure.Exceptions.ValidationException validationException)
            {
                errors = validationException.Errors;
            }
            return errors;
        }
    }
}
