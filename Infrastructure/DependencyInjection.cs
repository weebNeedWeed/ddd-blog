namespace Infrastructure;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Infrastructure.Authentication;
using Infrastructure.Common.Mapping;
using Infrastructure.Persistence.Administrator;
using Infrastructure.Persistence.Common;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.Configure<DatabaseOptions>(
            configuration.GetSection(DatabaseOptions.SectionName));
        services.AddSingleton<DatabaseService>();
        services.AddSingleton<IAdministratorRepository, AdministratorRepository>();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddSingleton<IPasswordHashingService, PasswordHashingService>();

        services.AddMapping();
        
        return services;
    }
}