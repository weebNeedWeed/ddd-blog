namespace Application.Common.Interfaces.Authentication;

public interface IPasswordHashingService
{
    string HashPassword(string plainTextPassword);

    bool Verify(string raw, string hashed);
}