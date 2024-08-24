using AutoMapper;
using Lojinha.Application.DTO;
using Lojinha.Domain.Entities;

namespace Lojinha.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Usuário
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, CadastroDTO>().ReverseMap();

            // Log
            CreateMap<Log, LogDTO>().ReverseMap();
        }
    }
}