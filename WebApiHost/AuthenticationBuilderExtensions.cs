using Core.Logic.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace WebApiHost
{
    internal static class AuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddJwtBearerWithIdentity(
            this AuthenticationBuilder builder,
            Action<JwtBearerOptions> configureOptions)
        {
            // Copy from Microsoft.Extensions.DependencyInjection.JwtBearerExtensions
            // AuthenticationBuilder AddJwtBearer(this AuthenticationBuilder builder, string authenticationScheme, string? displayName, Action<JwtBearerOptions> configureOptions)

            var serviceDescriptor = ServiceDescriptor.Singleton<IPostConfigureOptions<JwtBearerOptions>, JwtBearerPostConfigureOptions>();
            builder.Services.TryAddEnumerable(serviceDescriptor);
            
            return builder.AddScheme<JwtBearerOptions, JwtBearerHandlerWithIdentity>(
                JwtBearerDefaults.AuthenticationScheme,
                configureOptions);
        }
    }
}
