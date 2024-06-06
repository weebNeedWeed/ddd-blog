namespace Contracts.Authentication.Administrator;

public record AdministratorRegisterRequest(
    string UserName,
    string Email,
    string Password,
    string FirstName,
    string LastName);