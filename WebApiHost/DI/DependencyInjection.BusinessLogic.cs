using Core.DataAccess.Persons;
using Core.Logic;
using Microsoft.Extensions.DependencyInjection;

internal static partial class DependencyInjection
{
    public static void AddBusinessLogic(this IServiceCollection services)
    {
        services.AddSingleton<IClientService, ClientService>();
    }
}