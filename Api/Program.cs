using Api.Common;
using Application;
using Carter;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    
    builder.Host.UseSerilog((context, config) =>
    {
        config.ReadFrom.Configuration(context.Configuration);
    });

    builder.Services
        .AddInfrastructure(builder.Configuration)
        .AddApplication()
        .AddPresentation();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.MapCarter();
    app.UseSerilogRequestLogging();
    app.UseExceptionHandler("/error");

    app.MapControllers();
    
    app.UseAuthentication();
    app.UseAuthorization();
    
    app.Run();
}