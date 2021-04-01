using Core.Model;
using DI.Abstractions;
using Interoperation.Model.DTO.Cars;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Interoperation.Converters.DTO
{
    public sealed class ComponentRegisterer : IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddTransient<IConverter<Car, CarDto>, CarConverter>();
        }
    }
}
