using CheckSingletonScopeTransiateInstances.BusinessLogic;
using CheckSingletonScopeTransiateInstances.IInstallers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CheckSingletonScopeTransiateInstances.Installers
{
    public class DataInstaller : IInstaller
    {
        public void Installervice(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISingleTonClass, SingleTonClass>();
            services.AddScoped<IScopedClass, ScopedClass>();
            services.AddSingleton<ITransiateClass, TransiateClass>();
            services.AddTransient<IService, Service>();
        }
    }
}
