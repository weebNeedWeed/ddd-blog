namespace Application.Authentication.Administrator.Commands;

using ErrorOr;
using MediatR;

public record AdministratorRegisterCommand(
    string UserName,
    string Email,
    string Password,
    string FirstName,
    string LastName) : IRequest<ErrorOr<AdministratorRegisterResult>>;