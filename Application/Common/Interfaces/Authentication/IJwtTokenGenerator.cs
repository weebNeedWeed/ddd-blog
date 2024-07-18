namespace Application.Common.Interfaces.Authentication;

using Domain.AdministratorAggregate;

public interface IJwtTokenGenerator
{
    string GenerateToken(Administrator admin);
}