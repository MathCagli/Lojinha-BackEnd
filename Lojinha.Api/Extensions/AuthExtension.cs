using Lojinha.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Lojinha.Api.Extensions;

public static class AuthExtension
{
    public static void AddAuthentication(this IServiceCollection services, ConfigurationManager config)
    {
        var secretKey = config.GetSection("SecretKey").ToString();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.SecretKeyToken)),
                     ClockSkew = TimeSpan.Zero,
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidIssuer = "https://localhost:7048/",
                     ValidAudience = "http://localhost:4200",
                     RequireExpirationTime = true,
                 };
             });
    }
}