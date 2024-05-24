namespace Infrastructure.Persistence;

using Application.Common.Persistence;
using Domain.AdministratorAggregate;

public class AdministratorRepository : IAdministratorRepository
{
    private readonly List<Administrator> _administrators = new List<Administrator>();
    
    public async Task<Administrator?> GetByEmailAsync(string email)
    {
        await Task.CompletedTask;
        return this._administrators.FirstOrDefault(x => x.Email.Equals(email));
    }
}