using Lojinha.Application.DTO;

namespace Lojinha.Application.Services.Interfaces;

public interface ILogService
{
    Task<LogDTO> ObterPorId(int id);
    Task<List<LogDTO>> ListarTodos();
    Task GravarLog(LogDTO log);
    Task GravarLog(string descricao, string tipo);
}