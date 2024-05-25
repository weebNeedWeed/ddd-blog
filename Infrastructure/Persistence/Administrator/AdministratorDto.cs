namespace Infrastructure.Persistence.Administrator;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class AdministratorDto
{
    [BsonId]
    public Guid Id { get; set; }
    
    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime? LastLoginAt { get; set; }

    public List<Guid> Roles { get; set; } = new();
}