using Core.DataAccess.Persons;
using Microsoft.Extensions.DependencyInjection;

internal static partial class DependencyInjection
{
    public static void AddDataProviders(this IServiceCollection services)
    {
        services.AddSingleton<IClientDataProvider, ClientDataProvider>();
    }
}