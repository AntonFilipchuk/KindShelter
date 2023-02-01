using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next { get; set; }
        private readonly ILogger<ExceptionMiddleware> _logger;
        private IWebHostEnvironment _env { get; set; }

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IWebHostEnvironment env
        )
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException(
                        (int)HttpStatusCode.InternalServerError,
                        ex.Message,
                        ex.StackTrace is null ? string.Empty : ex.StackTrace.ToString()
                    )
                    : new ApiException((int)HttpStatusCode.InternalServerError);

                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, jsonOptions);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
