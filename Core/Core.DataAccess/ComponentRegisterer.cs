using Core.DataAccess.Persons;
using DI.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DataAccess
{
    public sealed class ComponentRegisterer : IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<IClientDataProvider, ClientDataProvider>();
        }
    }
}
