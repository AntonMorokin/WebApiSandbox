using Core.Configuration.Services;
using Core.Logic.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;

namespace WebApiHost.Extensions
{
    internal static class AuthenticationExtensions
    {
        private static TimeSpan __jwtValidationClockSkew = TimeSpan.FromSeconds(30);

        public static AuthenticationBuilder AddJwtAuthenticationWithIdentity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var builder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

            // Copied from Microsoft.Extensions.DependencyInjection.JwtBearerExtensions
            // AuthenticationBuilder AddJwtBearer(this AuthenticationBuilder builder, string authenticationScheme, string? displayName, Action<JwtBearerOptions> configureOptions)

            var serviceDescriptor = ServiceDescriptor.Singleton<IPostConfigureOptions<JwtBearerOptions>, JwtBearerPostConfigureOptions>();
            builder.Services.TryAddEnumerable(serviceDescriptor);

            return builder.AddScheme<JwtBearerOptions, JwtBearerHandlerWithIdentity>(
                JwtBearerDefaults.AuthenticationScheme,
                SetupJwtValidation(configuration));
        }

        private static Action<JwtBearerOptions> SetupJwtValidation(IConfiguration configuration)
        {
            return o => o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = LoadSecurityKey(configuration),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = __jwtValidationClockSkew
            };
        }

        /// <remarks>
        /// In ConfigureService we can't use options.
        /// So the secret key must be loaded in a straightforward way.
        /// </remarks>
        private static SecurityKey LoadSecurityKey(IConfiguration configuration)
        {
            var cert = X509CertificateLoader.LoadCertificateForJwtProcessing(configuration);
            return new X509SecurityKey(cert);
        }
    }
}
