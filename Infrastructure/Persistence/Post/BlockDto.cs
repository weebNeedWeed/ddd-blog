namespace Infrastructure.Persistence.Post;

public class BlockDto
{
    public int OrderNumber { get; set; }

    public string Content { get; set; } = null!;
    
    public Guid PostId { get; set; }
}