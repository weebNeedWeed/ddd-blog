namespace Domain.RoleAggregate;

using Domain.Common.Models;
using Domain.RoleAggregate.ValueObjects;

public class Role : AggregateRoot<RoleId>
{
    private readonly List<Permission> _permissions = new();
    
    private Role(
        RoleId id,
        string name,
        string description)
        : base(id)
    {
        this.Name = name;
        this.Description = description;
    }
    
    public string Name { get; private set; }
    
    public string Description { get; private set; }

    public IReadOnlyList<Permission> Permissions => this._permissions.AsReadOnly();

    public void AddPermission(Permission permission)
    {
        this._permissions.Add(permission);
    }
    
    public void RemovePermission(Permission permission)
    {
        this._permissions.Remove(permission);
    }
}