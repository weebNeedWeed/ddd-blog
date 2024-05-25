namespace Infrastructure.Persistence.Administrator;

using Application.Common.Interfaces.Persistence;
using Domain.AdministratorAggregate;
using Infrastructure.Persistence.Common;
using MongoDB.Driver;

public class AdministratorRepository : IAdministratorRepository
{
    private readonly IMongoCollection<AdministratorDto> _adminCollection;
    
    public AdministratorRepository(DatabaseService database)
    {
        this._adminCollection = database.GetCollection<AdministratorDto>("Administrators");
    }

    public async Task<Administrator?> GetByEmailAsync(string email)
    {
        var admin = await this._adminCollection
            .Find(x => x.Email == email)
            .FirstOrDefaultAsync();
        throw new NotImplementedException();
    }

    public Task<Administrator?> GetByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddAsync(Administrator admin)
    {
        throw new NotImplementedException();
    }
}