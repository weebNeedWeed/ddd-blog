namespace Domain.RoleAggregate.ValueObjects;

using Domain.Common.Models;

public class RoleId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;

    public static RoleId CreateUnique()
    {
        return new RoleId(Guid.NewGuid());
    }
    
    public static RoleId Create(Guid id)
    {
        return new RoleId(id);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}