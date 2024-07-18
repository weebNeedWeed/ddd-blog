namespace Api.Common;

using System.Reflection;
using Carter;
using Mapster;
using MapsterMapper;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddCarter();
        services.AddSwagger();
        services.AddMapping();
        return services;
    }
    
    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    private static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        var currentAssembly = Assembly.GetExecutingAssembly();
            
        config.Scan(currentAssembly);
        foreach (var refAssemblyName in currentAssembly.GetReferencedAssemblies())
        {
            var refAssembly = Assembly.Load(refAssemblyName);
            config.Scan(refAssembly);
        }

        services.AddSingleton(config);
        services.AddSingleton<IMapper, ServiceMapper>();

        return services;
    }
}