namespace Lojinha.Application.Helpers;

public class ResponseModel
{
    public string Mensagem { get; set; } = string.Empty;
    public bool InSucesso { get; set; } = true;
    public string? Erro { get; set; } = null;
    public object? Dados { get; set; } = null;
}