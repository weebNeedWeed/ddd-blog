namespace Infrastructure.Authentication;

using Application.Common.Interfaces.Authentication;

public class PasswordHashingService : IPasswordHashingService
{
    public string HashPassword(string plainTextPassword)
    {
        var hashed = BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        return hashed!;
    }
}