namespace Application.Authentication.Queries;

using ErrorOr;
using MediatR;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<LoginResult>>;