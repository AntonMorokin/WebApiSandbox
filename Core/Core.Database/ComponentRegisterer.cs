using Core.Database.Domain;
using Core.Database.Identity;
using DI.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Database
{
    public sealed class ComponentRegisterer : IComponentRegisterer
    {
        public void Register(IConfiguration configuration, IServiceCollection services)
        {
            string mainConnectionString = configuration.GetConnectionString("postgresql:main");
            services.AddDbContext<DataContext>(o => o.UseNpgsql(mainConnectionString));

            string identityConnectionString = configuration.GetConnectionString("postgresql:identity");
            services.AddDbContext<IdentityDataContext>(o => o.UseNpgsql(identityConnectionString));
        }
    }
}
