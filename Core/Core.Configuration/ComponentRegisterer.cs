using Core.Configuration.Options;
using Core.Configuration.Services;
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
                .AddOptions<JwtProcessingOptions>()
                .BindConfiguration(JwtProcessingOptions.SECTION_NAME)
                .ValidateDataAnnotations();

            services.AddSingleton<IX509CertificateLoader, X509CertificateLoader>();
        }
    }
}
