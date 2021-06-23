using Core.Database.Identity;
using Core.Logic.Cars;
using Core.Logic.Identity;
using Core.Logic.Settings;
using Core.Model.Identity;
using DI.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Logic
{
    public sealed class ComponentRegisterer : IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            // Nice try MS. Really good job.
            // At least you have given us a chance to disable this behavior.
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddScoped<ICarService, CarService>();

            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddIdentityCore<IdentifiedUser>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddUserManager<UserManager<IdentifiedUser>>()
                .AddSignInManager<SignInManager<IdentifiedUser>>();
            
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IAuthManager, AuthManager>();
            // services.AddScoped<IAuthManager, InMemoryAuthManager>();
        }
    }
}
