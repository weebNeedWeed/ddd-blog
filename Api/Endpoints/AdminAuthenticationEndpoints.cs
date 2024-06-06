namespace Api.Endpoints;

using Application.Authentication.Administrator.Commands;
using Carter;
using Contracts.Authentication.Administrator;
using MapsterMapper;
using MediatR;

public class AdminAuthenticationEndpoints : ICarterModule
{
    public static IResult Login()
    {
        throw new Exception("Hello");
    }
    
    public static async Task<IResult> Register(AdministratorRegisterRequest request, ISender mediator, IMapper mapper)
    {
        var command = mapper.Map<AdministratorRegisterCommand>(request);
        var result = await mediator.Send(command);

        return result.Match(
            val => Results.Ok(),
            err => Results.BadRequest(err));
    }
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth/admin");

        group.MapGet("/login", Login);
        
        group.MapPost("/register", Register);
    }
}