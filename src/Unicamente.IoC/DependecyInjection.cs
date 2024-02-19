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
            services.AddScoped<IImovelRepository, ImovelRepository>();
            services.AddScoped<IImovelService, ImovelService>();

            services.AddScoped<ITipoImovelRepository,TipoImovelRepository>();
            services.AddScoped<ITipoImovelService,TipoImovelService>();

            services.AddScoped<IComodoRepository, ComodoRepository>();
            services.AddScoped<IComodoService, ComodoService>();
            
            services.AddScoped<IComodoImovelRepository, ComodoImovelRepository>();
            services.AddScoped<IComodoImovelService, ComodoImovelService>();

            services.AddScoped<IInvestidorRepository, InvestidorRepository>();
            services.AddScoped<IInvestidorService, InvestidorService>();

            services.AddScoped<ICorretorRepository,CorretorRepository>();
            services.AddScoped<ICorretorService,CorretorService>();

            services.AddScoped<IEmpreendimentoRepository, EmpreendimentoRepository>();
            services.AddScoped<IEmpreendimentoService, EmpreendimentoService>();

            services.AddScoped<IImobiliariaRepository,ImobiliariaRepository>();
            services.AddScoped<IImobiliariaService,ImobiliariaService>();



            services.AddScoped<IConnectionFactory, DefaultSqlConnectionFactory>();
            services.AddScoped<ICorreios, Correios>();




            services.AddScoped<ILoginService, LoginService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            return services;
        }
    }
}
