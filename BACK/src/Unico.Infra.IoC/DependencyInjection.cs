using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unico.Application.Interfaces;
using Unico.Application.Mappings;
using Unico.Application.Services;
using Unico.Domain.Interfaces;
using Unico.Infra.Data;
using Unico.Infra.Data.Repositories;

namespace Unico.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IMaririRepository, MaririRepository>();
            services.AddScoped<IMaririService, MaririService>();

            services.AddScoped<IChacronaRepository, ChacronaRepository>();
            services.AddScoped<IChacronaService, ChacronaService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddScoped<IConnectionFactory, DefaultSqlConnectionFactory>();
            return services;
        }
    }
}