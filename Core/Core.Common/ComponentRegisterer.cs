using DI.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Common
{
    public sealed class ComponentRegisterer : IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<ITimeManager, TimeManager>();
        }
    }
}
