namespace Domain.PostAggregate.ValueObjects;

using Domain.Common.Models;

public class BlockId : ValueObject
{
    private BlockId(Guid value)
    {
        this.Value = value;
    }
    
    public Guid Value { get; private init; }

    public static BlockId CreateUnique()
    {
        return new BlockId(Guid.NewGuid());
    }
    
    public static BlockId Create(Guid value)
    {
        return new BlockId(value);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}