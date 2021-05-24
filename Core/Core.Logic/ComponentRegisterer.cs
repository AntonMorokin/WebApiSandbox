using Core.Database.Identity;
using Core.Logic.Cars;
using Core.Model;
using DI.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Logic
{
    public sealed class ComponentRegisterer : IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddTransient<ICarService, CarService>();

            services.AddIdentityCore<IdentifiedUser>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddSignInManager<SignInManager<IdentifiedUser>>();
        }
    }
}
