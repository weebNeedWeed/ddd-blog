namespace Contracts.Authentication;

public record LoginRequest(
    string UserNameOrEmail,
    string Password);


