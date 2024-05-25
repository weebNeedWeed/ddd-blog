namespace Application.Authentication.Administrator.Queries;

using ErrorOr;
using MediatR;

public record AdministratorLoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AdministratorLoginResult>>;