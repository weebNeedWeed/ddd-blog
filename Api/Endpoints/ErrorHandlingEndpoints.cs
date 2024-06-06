namespace Api.Endpoints;

using Carter;
using Microsoft.AspNetCore.Diagnostics;

public class ErrorHandlingEndpoints : ICarterModule
{
    public static IResult HandleError(HttpContext context, ILogger<ErrorHandlingEndpoints> logger)
    {
        var error = context.Features.Get<IExceptionHandlerFeature>()!.Error;
        
        logger.LogError(
            "An error occured: {error}",
            error);

        return Results.Problem(
            statusCode: StatusCodes.Status500InternalServerError,
            title: "An error occured while processing the request.");
    }
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.Map("/error", HandleError);
    }
}