using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.ILogging;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace APILayer.Middleware
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger= logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // سجل الخطأ
                _logger.LogError(ex, $"An unhandled exception occurred. Path: {context.Request.Path}");

                // أرجع الرد الموحد
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    Message = "An unexpected error occurred while processing your request. Please try again later."
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
