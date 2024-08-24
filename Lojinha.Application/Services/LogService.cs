using AutoMapper;
using Lojinha.Application.DTO;
using Lojinha.Application.Services.Interfaces;
using Lojinha.Domain.Entities;
using Lojinha.Domain.IRepository;
using Microsoft.AspNetCore.Http;

namespace Lojinha.Application.Services;

public class LogService : ILogService
{
    private readonly IRepository<Log> _repositoryLog;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogService(IRepository<Log> repositoryLog, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _repositoryLog = repositoryLog;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<LogDTO> ObterPorId(int id)
    {
        var retorno = _repositoryLog.ObterPorId(id);
        return _mapper.Map<LogDTO>(retorno);
    }

    public async Task<List<LogDTO>> ListarTodos()
    {
        var query = _repositoryLog.ListarTodos();
        return _mapper.Map<List<LogDTO>>(query); ;
    }

    public Task GravarLog(LogDTO log)
    {
        log.Evento = DateTime.Now.ToString() + " | " + log.Evento;
        _repositoryLog.Criar(_mapper.Map<Log>(log));
        return Task.CompletedTask;
    }

    public Task GravarLog(string descricao, string tipo)
    {

        var usuarioLogado = _httpContextAccessor.HttpContext.User.Claims.Count() > 0
            ? int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "ID").Value)
            : 0;
        Log log = new Log();
        log.Evento = DateTime.Now.ToString() + " | " + descricao;
        log.Tipo = tipo;
        log.Usuario = usuarioLogado > 0 ? usuarioLogado : 0;

        _repositoryLog.Criar(log);
        return Task.CompletedTask;
    }
}