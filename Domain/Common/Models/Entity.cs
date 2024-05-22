namespace Domain.Common.Models;

public abstract class Entity<TId>(TId id) : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected init; } = id;

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
    
    public bool Equals(Entity<TId>? other)
    {
        return this == other;
    }

    public override bool Equals(object? obj)
    {
        return obj is not null
               && obj is Entity<TId> entity
               && entity.Id.Equals(this.Id);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}