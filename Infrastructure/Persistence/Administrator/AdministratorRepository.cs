namespace Infrastructure.Persistence.Administrator;

using Application.Common.Interfaces.Persistence;
using Domain.AdministratorAggregate;
using Infrastructure.Persistence.Common;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

public class AdministratorRepository : IAdministratorRepository
{
    private readonly IMongoCollection<AdministratorDto> _adminCollection;
    private readonly IMapper _mapper;
    private readonly ILogger<AdministratorRepository> _logger;
    
    public AdministratorRepository(DatabaseService database, IMapper mapper, ILogger<AdministratorRepository> logger)
    {
        this._mapper = mapper;
        this._logger = logger;
        this._adminCollection = database.GetCollection<AdministratorDto>("Administrators");
    }

    public async Task<Administrator?> GetByEmailAsync(string email)
    {
        var admin = await this._adminCollection
            .Find(x => x.Email == email)
            .FirstOrDefaultAsync();
        return admin is null ? null : this._mapper.Map<Administrator>(admin);
    }

    public async Task<Administrator?> GetByUserNameAsync(string userName)
    {
        var admin = await this._adminCollection
            .Find(x => x.UserName == userName)
            .FirstOrDefaultAsync();
        var x = this._mapper.Map<Administrator>(admin);
        return admin is null ? null : x;
    }

    public async Task<bool> AddAsync(Administrator admin)
    {
        var adminDto = this._mapper.Map<AdministratorDto>(admin);
        try
        {
            await this._adminCollection.InsertOneAsync(adminDto);
            return true;
        }
        catch (Exception ex)
        {
            this._logger.LogError(
                "Error occured while saving administrator {@administrator}, with exception {@exception}", 
                adminDto,
                ex);
            return false;
        }
    }
}