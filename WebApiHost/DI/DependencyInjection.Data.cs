using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiHost.DI
{
    internal static partial class DependencyInjection
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("postgresql");
            services.AddDbContext<DataContext>(o => o.UseNpgsql(connectionString));
        }
    }
}
