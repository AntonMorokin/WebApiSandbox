using Core.Database.Identity;
using Core.Logic.Cars;
using Core.Logic.Identity;
using Core.Logic.Settings;
using Core.Model.Identity;
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
            services.AddScoped<ICarService, CarService>();

            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddIdentityCore<IdentifiedUser>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddUserManager<UserManager<IdentifiedUser>>()
                .AddSignInManager<SignInManager<IdentifiedUser>>();
            
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IAuthManager, AuthManager>();
        }
    }
}
