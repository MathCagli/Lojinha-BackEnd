using Lojinha.Application.DTO;
using Lojinha.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.Api.Controllers;

public class UsuarioController : BaseController
{
    private IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("listarTodos")]
    [AllowAnonymous]
    public async Task<IActionResult> ListarTodos()
    {
        List<UsuarioDTO> usuario = await _usuarioService.ListarTodos();
        return Ok(usuario);
    }
}
