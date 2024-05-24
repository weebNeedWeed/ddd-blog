namespace Infrastructure;

using Application.Common.Persistence;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IAdministratorRepository, AdministratorRepository>();
        return services;
    }
}