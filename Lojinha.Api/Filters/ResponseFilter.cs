using Lojinha.Application.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Lojinha.Api.Filters
{
    public class ResponseFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // Cria a estrutura de retorno padrão
            ResponseModel responseObject = new ResponseModel
            {
                Mensagem = "Requisição concluída com sucesso",
                InSucesso = true,
                Dados = ((Microsoft.AspNetCore.Mvc.ObjectResult)context.Result).Value
            };

            context.HttpContext.Response.ContentType = "application/json";
            var jsonResponse = JsonSerializer.Serialize(responseObject);
            await context.HttpContext.Response.WriteAsync(jsonResponse);
        }
    }
}