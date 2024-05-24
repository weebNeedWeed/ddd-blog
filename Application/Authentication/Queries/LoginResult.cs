namespace Application.Authentication.Queries;

using Domain.AdministratorAggregate;

public record LoginResult(
    Administrator Administrator,
    string Token);