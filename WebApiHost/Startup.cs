using Core.Logic.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace WebApiHost
{
    public class Startup
    {
        private static TimeSpan __jwtValidationClockSkew = TimeSpan.FromSeconds(30);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddApplicationPart(LoadControllersAssembly());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiHost", Version = "v1" });
            });

            // TODO Maybe it would be better to move these settings to a special place.
            // For example, special extension methods.
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearerWithIdentity(o => o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = LoadSecurityKey(),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = __jwtValidationClockSkew
                });

            services
                .AddAuthorization(o =>
                {
                    o.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                    o.AddPolicy("IsManager", p => p.RequireClaim("IsManager", bool.TrueString));
                });

            DI.Container.RegisterComponents(Configuration, services);
        }

        private static Assembly LoadControllersAssembly()
        {
            return Assembly.Load("Interoperation.Controllers");
        }

        /// <remarks>
        /// In ConfigureService we can't use options.
        /// So the secret key must be loaded in a straightforward way.
        /// </remarks>
        private SecurityKey LoadSecurityKey()
        {
            var key = Configuration.GetValue<string>("Jwt:SecretKey");
            var bytes = Convert.FromHexString(key);
            return new SymmetricSecurityKey(bytes);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiHost v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
