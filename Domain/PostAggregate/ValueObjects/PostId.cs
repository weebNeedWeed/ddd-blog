using Domain.AuthorAggregate.ValueObjects;
using Domain.Common.Models;

namespace Domain.PostAggregate.ValueObjects;
public sealed class PostId : ValueObject
{
    public Guid Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private PostId(Guid value)
    {
        Value = value;
    }

    public static PostId CreateUnique()
    {
        return new PostId(Guid.NewGuid());
    }
}
