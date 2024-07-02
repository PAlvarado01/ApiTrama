using Grupo5.Business.Interfaces;
using Grupo5.Business.Services;

namespace Grupo5.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {        
            services.AddScoped<IGeneratorTrama, GenerarTramaService>();

            return services;
        }
    }

}
