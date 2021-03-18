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
            string connectionString = configuration.GetConnectionString("postgresql");
            services.AddDbContext<DataContext>(o => o.UseNpgsql(connectionString));
        }
    }
}
