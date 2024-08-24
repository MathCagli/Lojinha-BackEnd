using Lojinha.Application.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lojinha.Api.Filters;

public class ResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var statusCode = ((ObjectResult)context.Result).StatusCode;

        // Cria a estrutura de retorno padrão
        ResponseModel responseObject = new ResponseModel
        {
            Mensagem = statusCode == 200 ? "Requisição concluída com sucesso" : "Erro - " + statusCode.ToString(),
            InSucesso = statusCode == 200 ? true : false,
            Dados = statusCode == 200 ? ((ObjectResult)context.Result).Value : null,
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        context.HttpContext.Response.ContentType = "application/json";
        context.HttpContext.Response.StatusCode = statusCode ?? 500;
        var jsonResponse = JsonSerializer.Serialize(responseObject, options);
        await context.HttpContext.Response.WriteAsync(jsonResponse);
    }
}