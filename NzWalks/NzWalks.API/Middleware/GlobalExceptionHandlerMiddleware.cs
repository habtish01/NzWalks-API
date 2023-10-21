using NzWalks.API.DTOs;
using System.Net;
using Serilog;

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
                Log.Error(ex,$"{errorId} : {ex.Message}"); 
                //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                Response response = new();
                response.Id = errorId;
                response.StatusCode= (int)HttpStatusCode.InternalServerError;       
                response.ErrorMessage =ex.Message;
                await context.Response.WriteAsJsonAsync(response);

            }
        }

        
    }
}
