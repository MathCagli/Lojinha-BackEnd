using Lojinha.Api.Extensions;
using Lojinha.Api.Filters;
using Lojinha.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Lojinha.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthentication(builder.Configuration);
        builder.Services.AddServices(builder.Configuration);
        builder.Services.AddSwagger(builder.Configuration);
        builder.Services.AddControllers();
        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Services.AddScoped<ErrorFilter>();
        builder.Services.AddScoped<ResponseFilter>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDbContext<LojinhaContext>(c =>
        {
            c.UseLazyLoadingProxies()
             .UseSqlServer(builder.Configuration.GetConnectionString("LojinhaConnection"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseCors("corsdev");
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lojinha v1"));
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}