using Core.Model.Domain;
using Core.Model.Identity;
using DI.Abstractions;
using Interoperation.Converters.DTO.Private;
using Interoperation.Converters.DTO.Public;
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
            services.AddScoped<IConverter<Car, PublicCarDto>, PublicCarConverter>();
            services.AddScoped<IConverter<AuthenticatedUser, PublicAuthenticatedUserDto>, PublicAuthenticatedUserConverter>();

            services.AddScoped<IConverter<Car, PrivateCarDto>, PrivateCarConverter>();
            services.AddScoped<IConverter<Drive, PrivateDriveDto>, PrivateDriveConverter>();
        }
    }
}
