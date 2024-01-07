using Domain.Common.Models;

namespace Domain.AuthorAggregate.ValueObjects;

public sealed class AuthorId : ValueObject
{
    public Guid Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private AuthorId(Guid value)
    {
        Value = value;
    }

    public static AuthorId CreateUnique()
    {
        return new AuthorId(Guid.NewGuid());
    }
}
