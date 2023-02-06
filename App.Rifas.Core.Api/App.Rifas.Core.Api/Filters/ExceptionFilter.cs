using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace App.Rifas.Core.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ErrorVM response = new ErrorVM();
            HttpStatusCode sttCode = HttpStatusCode.InternalServerError;
            response.Message = context.Exception.Message;
            if (context.Exception is NotFoundException)
            {
                sttCode = HttpStatusCode.NotFound;
            }
            if(context.Exception is BadRequestException)
            {
                sttCode = HttpStatusCode.BadRequest;
            }

            context.Result = new JsonResult(response) { StatusCode = (int)sttCode };
            

        }
    }
}
