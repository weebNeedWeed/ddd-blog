namespace Infrastructure.Persistence.Common;

using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

public sealed class DatabaseService
{
    public DatabaseService(IOptions<DatabaseOptions> databaseOptions)
    {
        this.MongoClient = new MongoClient(databaseOptions.Value.ConnectionString);

        this.MongoDatabase = this.MongoClient.GetDatabase(databaseOptions.Value.DatabaseName);
    }
    
    public MongoClient MongoClient { get; }
    
    public IMongoDatabase MongoDatabase { get; }
    
    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return this.MongoDatabase.GetCollection<T>(name);
    }
}