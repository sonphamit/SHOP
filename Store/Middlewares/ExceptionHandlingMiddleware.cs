using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Store.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                HandleException(httpContext, ex);
            }
        }

            private void HandleException(HttpContext context, Exception exception)
            {
                if (exception == null)
                    return;

                //logger.LogError(exception.ToString());
                var code = HttpStatusCode.InternalServerError;
                string message;
                if (exception is UnauthorizedAccessException)
                {
                    code = HttpStatusCode.Unauthorized;
                    message = exception.Message;
                }
                else if (exception is MethodAccessException)
                {
                    code = HttpStatusCode.NotFound;
                    message = exception.Message;
                }
                else if (exception is ArgumentException)
                {
                    code = HttpStatusCode.BadRequest;
                    message = exception.Message;
                }
                else if (exception is DbUpdateException)
                {
                    code = HttpStatusCode.BadRequest;
                    message = exception.InnerException != null ? exception.InnerException.Message : exception.Message;
                }
                else
                {
                    message = "Server error. Please contact admin to support";
                }

                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)code;
                
            }

        }
}
