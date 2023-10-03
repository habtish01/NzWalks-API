using NzWalks.API.DTOs;
using System.Net;

namespace NzWalks.API.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
         
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                logger.LogError(ex,$"{errorId} : {ex.Message}"); 
                //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                Response response = new();
                response.Id = errorId;
                response.StatusCode= (int)HttpStatusCode.InternalServerError;       
                response.ErrorMessage = "Something went wrong! we try to fix soon. we appologize for this!";
                await context.Response.WriteAsJsonAsync(response);

            }
        }

        
    }
}
