namespace Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
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
    
    public bool Equals(ValueObject? other)
    {
        return this == other;
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject valueObject
               && valueObject.GetEqualityComponents()
                   .SequenceEqual(this.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return this.GetEqualityComponents()
            .Select(x => x.GetHashCode())
            .Aggregate((x1, x2) => x1 ^ x2);
    }
    
    protected abstract IEnumerable<object> GetEqualityComponents();
}