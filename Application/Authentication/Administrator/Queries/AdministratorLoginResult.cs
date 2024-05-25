namespace Application.Authentication.Administrator.Queries;

using Domain.AdministratorAggregate;

public record AdministratorLoginResult(
    Administrator Administrator,
    string Token);