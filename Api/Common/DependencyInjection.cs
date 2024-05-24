namespace Api.Common;

using Carter;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddCarter();
        return services;
    }
}