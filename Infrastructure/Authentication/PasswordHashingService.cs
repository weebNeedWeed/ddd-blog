namespace Infrastructure.Authentication;

using Application.Common.Interfaces.Authentication;
using BCrypt.Net;

public class PasswordHashingService : IPasswordHashingService
{
    public string HashPassword(string plainTextPassword)
    {
        var hashed = BCrypt.HashPassword(plainTextPassword);
        return hashed!;
    }

    public bool Verify(string raw, string hashed)
    {
        return BCrypt.Verify(raw, hashed);
    }
}