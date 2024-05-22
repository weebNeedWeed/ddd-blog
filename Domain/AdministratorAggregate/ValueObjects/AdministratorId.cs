namespace Domain.AdministratorAggregate.ValueObjects;

using Domain.Common.Models;

public class AdministratorId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;
    
    public static AdministratorId CreateUnique()
    {
        return new AdministratorId(Guid.NewGuid());
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}