using AutoMapper;
using Lojinha.Application.DTO;
using Lojinha.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.Api.Controllers
{
    public class AuthController : BaseController
    {
        private IAuthService _authService;
        //private IMapper _mapper;

        public AuthController(IAuthService authService/*, IMapper mapper*/)
        {
            _authService = authService;
            //_mapper = mapper;
        }

        /// <summary>
        /// Autentica o Usuário com as Informações do Login
        /// </summary>
        /// <param name="login">Objeto que Contém as Credenciais do Usuário.</param>
        /// <returns>
        /// Retorna os Dados do Usuário.
        /// </returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<CadastroDTO>> Login(LoginDTO login)
        {
            CadastroDTO usuario = await _authService.Login(login);
            return usuario;
        }

        [HttpPost("cadastrarUsuario")]
        [AllowAnonymous]
        public async Task<ActionResult<CadastroDTO>> CadastrarUsuario(CadastroDTO novoUsuario)
        {
            CadastroDTO usuario = await _authService.CadastrarUsuario(novoUsuario);
            return usuario;
        }

        // Esqueci Senha
    }
}
