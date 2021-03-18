using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Abstractions
{
    public interface IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services);
    }
}
