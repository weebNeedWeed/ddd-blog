namespace Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        return obj is not null 
            && obj is ValueObject valueObject
            && valueObject.GetEqualityComponents().SequenceEqual(GetEqualityComponents()); 
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x.GetHashCode())
            .Aggregate((a, b) => a ^ b);
    }

    public bool Equals(ValueObject? other)
    {
        return Equals((object?) other);
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return left is not null
            && right is not null
            && left.Equals(right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }
}
