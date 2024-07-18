namespace Domain.PostAggregate.ValueObjects;

using Domain.Common.Models;

public class PostId : ValueObject
{
    private PostId(Guid value) => this.Value = value;
    
    public Guid Value { get; }
    
    public static PostId CreateUnique() => new PostId(Guid.NewGuid());
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}