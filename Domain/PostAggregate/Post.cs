using Domain.Common.Models;
using Domain.PostAggregate.ValueObjects;

namespace Domain.PostAggregate;
public sealed class Post : AggregateRoot<PostId>
{
    public Post(PostId id) : base(id)
    {
    }
}
