using Microsoft.OpenApi.Models;

namespace Lojinha.Api.Extensions;

public static class SwaggerExtension
{
    public static void AddSwagger(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type =  SecuritySchemeType.ApiKey,
                Description = "Adicione o token JWT para fazer as requisições na APIs",
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}