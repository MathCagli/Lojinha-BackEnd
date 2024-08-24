using Lojinha.Application.Helpers;
using Lojinha.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;

namespace Lojinha.Api.Filters;

public class ErrorFilter : IAsyncExceptionFilter
{
    private readonly ILogService _logService;

    public ErrorFilter(ILogService logService)
    {
        _logService = logService;
    }

    public async Task OnExceptionAsync(ExceptionContext context)
    {
        await _logService.GravarLog(context.Exception.Message + " - " + context.Exception.GetType().Name, "ERRO");

        ResponseModel responseObject = new ResponseModel
        {
            Mensagem = "Não foi possível processar a solicitação",
            InSucesso = false,
            Erro = context.Exception.Message
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        context.HttpContext.Response.ContentType = "application/json";
        var jsonResponse = JsonSerializer.Serialize(responseObject, options);
        context.Result = new JsonResult(jsonResponse)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }
}