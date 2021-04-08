using Core.Model;
using DI.Abstractions;
using Interoperation.Converters.DTO.Private;
using Interoperation.Model.DTO.Private;
using Interoperation.Model.DTO.Public;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Interoperation.Converters.DTO
{
    public sealed class ComponentRegisterer : IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddTransient<IConverter<Car, PublicCarDto>, PublicCarConverter>();

            services.AddTransient<IConverter<Car, PrivateCarDto>, PrivateCarConverter>();
            services.AddTransient<IConverter<Drive, PrivateDriveDto>, PrivateDriveConverter>();
        }
    }
}
