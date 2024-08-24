using Lojinha.Application.DTO;

namespace Lojinha.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> ListarTodos();
    }
}
