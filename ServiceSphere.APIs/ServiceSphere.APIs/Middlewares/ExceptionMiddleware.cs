using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ServiceSphere.APIs.Errors;
using System.Net;
using System.Text.Json;

namespace ServiceSphere.APIs.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }
        public async Task InvokeAsync(HttpContext context) {

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                //log exception in development environment
                logger.LogError(ex,ex.Message);

                //log error in the production to DB or Files 
                //-----left-----

                //header
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                //body 
                var response = env.IsDevelopment() ? new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                    new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);

                //json format
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var json = JsonSerializer.Serialize(response, options);

                //body
                context.Response.WriteAsync(json);
            }
        }
    }
}
