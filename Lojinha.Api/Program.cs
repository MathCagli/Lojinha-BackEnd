using Lojinha.Api.Filters;
using Lojinha.Application.Helpers;
using Lojinha.Application.Services;
using Lojinha.Application.Services.Interfaces;
using Lojinha.Domain.IRepository;
using Lojinha.Repository.Context;
using Lojinha.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Lojinha.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            builder.Services.AddDbContext<LojinhaContext>(c =>
            {
                c.UseLazyLoadingProxies()
                 .UseSqlServer(builder.Configuration.GetConnectionString("LojinhaConnection"));
            });


            builder.Services.AddScoped<ErrorFilter>();
            builder.Services.AddScoped<ResponseFilter>();

            // Services
            builder.Services.AddScoped<IAuthService, AuthService>();

            // Repositories
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lojinha v1"));
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}