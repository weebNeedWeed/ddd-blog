namespace Domain.PostAggregate;

using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.PostAggregate.ValueObjects;

public class Post(PostId id) : AggregateRoot<PostId>(id)
{
    public string Title { get; }
    
    public string ShortDescription { get; }
    
    public Image ThumbnailImage { get; }
    
    public Image CoverImage { get; }
}