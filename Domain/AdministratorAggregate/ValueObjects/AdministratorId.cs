namespace Domain.AdministratorAggregate.ValueObjects;

using Domain.Common.Models;

public class AdministratorId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;
    
    public static AdministratorId CreateUnique()
    {
        return new AdministratorId(Guid.NewGuid());
    }

    public static AdministratorId Create(Guid id)
    {
        return new AdministratorId(id);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}