namespace Infrastructure.Persistence.Post;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class PostDto
{
    [BsonId]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public ImageDto ThumbnailImage { get; set; } = null!;

    public ImageDto CoverImage { get; set; } = null!;
    
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid AdministratorId { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public List<Guid> Blocks { get; set; } = new();
}