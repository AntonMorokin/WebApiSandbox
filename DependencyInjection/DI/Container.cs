using DI.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DI
{
    public static class Container
    {
        public static void RegisterComponents(IConfiguration configuration, IServiceCollection services)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            foreach (IComponentRegisterer registerer in CreateKnownRegisterers())
            {
                registerer.Register(configuration, services);
            }
        }

        private static IEnumerable<IComponentRegisterer> CreateKnownRegisterers()
        {
            // Of course I could use reflection.
            // But I don't realy want it because of performance and unexpected behavior.

            yield return new Core.Common.ComponentRegisterer();
            yield return new Core.Configuration.ComponentRegisterer();
            yield return new Core.Database.ComponentRegisterer();
            yield return new Core.DataAccess.ComponentRegisterer();
            yield return new Core.Logic.ComponentRegisterer();

            yield return new Interoperation.Converters.DTO.ComponentRegisterer();
        }
    }
}
