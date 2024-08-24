using AutoMapper;
using Lojinha.Application.DTO;
using Lojinha.Application.Services.Interfaces;
using Lojinha.Domain.Entities;
using Lojinha.Domain.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Lojinha.Application.Services;

public class AuthService : IAuthService
{
    private readonly SymmetricSecurityKey _key;
    private readonly int _tokenExpTime;

    private readonly IRepository<Usuario> usuarioRepository;
    private readonly IMapper mapper;

    public AuthService(IRepository<Usuario> usuarioRepository, IMapper mapper)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.SecretKeyToken));
        _tokenExpTime = 4;

        this.usuarioRepository = usuarioRepository;
        this.mapper = mapper;
    }

    public async Task<CadastroDTO> Login(LoginDTO dto)
    {
        try
        {
            Usuario usuario = this.usuarioRepository.ListarTodos().FirstOrDefault(u => u.Login == dto.Login);
            if (usuario == null) return null;

            using HMACSHA512 hmac = new HMACSHA512(usuario.SenhaSalt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Senha));

            if (!computedHash.SequenceEqual(usuario.SenhaHash)) throw new Exception("Senha Inválida!");

            usuario.Token = CriarToken(usuario);

            CadastroDTO retorno = this.mapper.Map<CadastroDTO>(usuario);
            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<CadastroDTO> CadastrarUsuario(CadastroDTO dto)
    {
        try
        {
            using var hmac = new HMACSHA512();
            var senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.SenhaTxt));
            var senhaSalt = hmac.Key;

            Usuario usuario = new Usuario()
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Login = dto.Login,
                SenhaHash = senhaHash,
                SenhaSalt = senhaSalt
            };
            usuario = this.usuarioRepository.Criar(usuario);

            CadastroDTO retorno = this.mapper.Map<CadastroDTO>(usuario);
            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string CriarToken(Usuario usuario)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("ID", usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
        }),
            Expires = DateTime.UtcNow.AddHours(_tokenExpTime),
            SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}