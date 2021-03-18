using DI.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Logic
{
    public sealed class ComponentRegisterer : IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<IClientService, ClientService>();
        }
    }
}
