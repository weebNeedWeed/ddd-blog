namespace Contracts.Authentication.Administrator;

public record AdministratorLoginRequest(
    string UserName, 
    string Password);