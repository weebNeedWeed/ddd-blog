namespace Application.Authentication.Administrator.Queries;

using ErrorOr;
using MediatR;

public record AdministratorLoginQuery(
    string UserName,
    string Password) : IRequest<ErrorOr<AdministratorLoginResult>>;