namespace Domain.Common.Models;
public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; private set; }

    protected Entity(TId id)
    {
        Id = id;    
    }

    public override bool Equals(object? obj)
    {
        return obj is not null
            && obj is Entity<TId> entity
            && entity.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return left is not null
            && right is not null
            && left.Equals(right);  
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}
