using Lojinha.Application.Helpers;
using Lojinha.Application.Services;
using Lojinha.Application.Services.Interfaces;
using Lojinha.Domain.IRepository;
using Lojinha.Repository.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Lojinha.Api.Extensions;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddCors(p => p.AddPolicy("corsdev", builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        }));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<ILogService, LogService>();

        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}