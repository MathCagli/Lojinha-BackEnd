using Lojinha.Application.DTO;

namespace Lojinha.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<CadastroDTO> Login(LoginDTO dto);
        Task<CadastroDTO> CadastrarUsuario(CadastroDTO dto);
    }
}
