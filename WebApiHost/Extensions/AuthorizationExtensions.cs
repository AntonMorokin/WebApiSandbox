using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiHost.Extensions
{
    internal static class AuthorizationExtensions
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            return services.AddAuthorization(o =>
            {
                o.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                o.AddPolicy("IsManager", p => p.RequireClaim("IsManager", bool.TrueString));
            });
        }
    }
}
