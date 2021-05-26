using Core.Configuration.Options;
using DI.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration
{
    public sealed class ComponentRegisterer : IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            services
                .AddOptions<JwtGenerationOptions>()
                .BindConfiguration(JwtGenerationOptions.SECTION_NAME)
                .ValidateDataAnnotations();
        }
    }
}
