namespace Application;

using System.Reflection;
using Application.Common.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(c =>
        {
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
            c.RegisterServicesFromAssembly(assembly);
        });
        
        return services;
    } 
}