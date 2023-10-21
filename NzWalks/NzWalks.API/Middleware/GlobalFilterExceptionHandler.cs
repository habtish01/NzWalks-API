using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NzWalks.API.DTOs;

namespace NzWalks.API.Middleware
{
    public class GlobalFilterExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
           
            Response response = new();
            response.Id= Guid.NewGuid(); 
            response.StatusCode = 500;
            response.ErrorMessage=context.Exception.Message;
            //response.ErrorMessage = "Filter exception handling";
            context.Result=new JsonResult(response);    
        }
    }
}
