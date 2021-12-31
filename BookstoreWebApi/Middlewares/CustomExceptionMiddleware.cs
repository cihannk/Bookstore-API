using System.Diagnostics;
using System.Net;
using BookstoreWebApi.Services;
using Newtonsoft.Json;

namespace BookstoreWebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                _logger.Write(message);
                await _next(context);
                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms";
                _logger.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, watch, ex);
            }
        }

        private Task HandleException(HttpContext context, Stopwatch watch, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            string message = "[Error] HTTP " + context.Request.Method + " - "+ context.Response.StatusCode + " Error Message: "+ ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            _logger.Write(message);

            var result = JsonConvert.SerializeObject(new {error = ex.Message}, Formatting.None);

            return context.Response.WriteAsync(result);

        }
    }
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}