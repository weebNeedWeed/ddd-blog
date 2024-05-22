namespace Domain.RoleAggregate.ValueObjects;

using Domain.Common.Models;

public enum PermissionLevel
{
    Read,
    Write,
    Delete,
    Manage,
}

public class Permission : ValueObject
{
    private Permission(
        string name, 
        string description, 
        string scope, 
        PermissionLevel level)
    {
        this.Name = name;
        this.Description = description;
        this.Scope = scope;
        this.Level = level;
    }

    public string Name { get; }
    
    public string Description { get; }
    
    public string Scope { get; }
    
    public PermissionLevel Level { get; }

    public static Permission Create(
        string name, 
        string description, 
        string scope, 
        PermissionLevel level)
    {
        return new Permission(name, description, scope, level);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Name;
        yield return this.Description;
        yield return this.Scope;
        yield return this.Level;
    }
}