namespace Api.Endpoints;

using Application.Authentication.Administrator.Commands;
using Application.Authentication.Administrator.Queries;
using Carter;
using Contracts.Authentication.Administrator;
using MapsterMapper;
using MediatR;

public class AdminAuthenticationEndpoints : ICarterModule
{
    public static async Task<IResult> Login(AdministratorLoginRequest request, IMapper mapper, ISender mediator)
    {
        var query = mapper.Map<AdministratorLoginQuery>(request);
        var loginResult = await mediator.Send(query);

        return loginResult.Match(
            val => Results.Ok(val),
            errors => CustomResults.Errors(errors));
    }
    
    public static async Task<IResult> Register(AdministratorRegisterRequest request, ISender mediator, IMapper mapper)
    {
        var command = mapper.Map<AdministratorRegisterCommand>(request);
        var result = await mediator.Send(command);

        return result.Match(
            val => Results.Ok(val),
            err => CustomResults.Errors(err));
    }
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth/admin");

        group.MapPost("/login", Login);
        
        group.MapPost("/register", Register);
    }
}