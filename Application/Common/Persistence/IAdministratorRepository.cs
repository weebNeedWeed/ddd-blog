namespace Application.Common.Persistence;

using Domain.AdministratorAggregate;

public interface IAdministratorRepository
{
    Task<Administrator?> GetByEmailAsync(string email);
}