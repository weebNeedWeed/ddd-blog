namespace Application.Common.Interfaces.Persistence;

using Domain.AdministratorAggregate;

public interface IAdministratorRepository
{
    Task<Administrator?> GetByEmailAsync(string email);
    
    Task<Administrator?> GetByUserNameAsync(string userName);
    
    Task<bool> AddAsync(Administrator admin);
}