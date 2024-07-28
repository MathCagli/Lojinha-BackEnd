using Lojinha.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Lojinha.Api.Filters
{
    public class ErrorFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            ResponseModel responseObject = new ResponseModel
            {
                Mensagem = "Não foi possível processar a solicitação",
                InSucesso = false,
                Erro = context.Exception.Message
            };

            context.Result = new JsonResult(responseObject)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
