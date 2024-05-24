namespace Api.Endpoints.Authentication;

using Carter;

public class AdminAuthenticationEndpoints : ICarterModule
{
    public static IResult Login()
    {
        return Results.Ok();
    }
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth/admin");

        group.MapGet("/login", Login);
    }
}