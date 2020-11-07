using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Touruta.Core.Exceptions;

namespace Touruta.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var excetion = (BusinessException) context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = excetion.Message
                };

                var json = new
                {
                    erros = new []{validation}
                };
                
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}