using AutoMapper;
using Lojinha.Application.DTO;
using Lojinha.Application.Services.Interfaces;
using Lojinha.Domain.Entities;
using Lojinha.Domain.IRepository;

namespace Lojinha.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IRepository<Usuario> usuarioRepository;
    private readonly IMapper mapper;

    public UsuarioService(IRepository<Usuario> usuarioRepository, IMapper mapper)
    {
        this.usuarioRepository = usuarioRepository;
        this.mapper = mapper;
    }

    public async Task<List<UsuarioDTO>> ListarTodos()
    {
        try
        {
            List<Usuario> listaUsuario = this.usuarioRepository.ListarTodos().ToList();
            List<UsuarioDTO> retorno = this.mapper.Map<List<UsuarioDTO>>(listaUsuario);
            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}