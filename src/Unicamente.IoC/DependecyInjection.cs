using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Unicamente.Application.ExternalServices.Correios;
using Unicamente.Application.Interfaces;
using Unicamente.Application.Mappings;
using Unicamente.Application.Services;
using Unicamente.Domain.Interfaces;
using Unicamente.Repository;

namespace Unicamente.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
  IConfiguration configuration)
        {

            services.AddScoped<IImobiliariaRepository, ImobiliariaRepository>();
            services.AddScoped<IImobiliariaService, ImobiliariaService>();


            services.AddScoped<IRecipienteRepository, RecipienteRepository>();
            services.AddScoped<IRecipienteService, RecipienteService>();

            services.AddScoped<IMaririRepository, MaririRepository>();
            services.AddScoped<IMaririService, MaririService>();

            services.AddScoped<IChacronaRepository, ChacronaRepository>();
            services.AddScoped<IChacronaService, ChacronaService>();

            services.AddScoped<IVegetalRepository, VegetalRepository>();
            services.AddScoped<IVegetalService, VegetalService>();

            services.AddScoped<IConnectionFactory, DefaultSqlConnectionFactory>();
            services.AddScoped<ICorreios, Correios>();


            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            return services;
        }
    }
}
