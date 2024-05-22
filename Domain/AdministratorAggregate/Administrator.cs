namespace Domain.AdministratorAggregate;

using Domain.AdministratorAggregate.ValueObjects;
using Domain.Common.Models;
using Domain.RoleAggregate.ValueObjects;

public class Administrator : AggregateRoot<AdministratorId>
{
    private readonly List<RoleId> _roles = new();
    
    private Administrator(
        AdministratorId id,
        string userName,
        string email,
        string hashedPassword,
        string firstName,
        string lastName,
        DateTime createdAt,
        DateTime? lastLoginAt)
        : base(id)
    {
        this.UserName = userName;
        this.Email = email;
        this.HashedPassword = hashedPassword;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.CreatedAt = createdAt;
        this.LastLoginAt = lastLoginAt;
    }

    public string UserName { get; private set; }

    public string Email { get; private set; }

    public string HashedPassword { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? LastLoginAt { get; private set; }

    public IReadOnlyList<RoleId> Roles => this._roles.AsReadOnly();

    public static Administrator Create(
        string userName,
        string email,
        string hashedPassword,
        string firstName,
        string lastName,
        DateTime createdAt,
        DateTime? lastLoginAt)
    {
        return new Administrator(
            AdministratorId.CreateUnique(),
            userName,
            email,
            hashedPassword,
            firstName,
            lastName,
            createdAt,
            lastLoginAt);
    }

    public void AddRole(RoleId roleId)
    {
        this._roles.Add(roleId);
    }
    
    public void RemoveRole(RoleId roleId)
    {
        this._roles.Remove(roleId);
    }

    public void UpdateLastLogin(DateTime lastLogin)
    {
        if (this.LastLoginAt is not null && this.LastLoginAt > lastLogin)
        {
            throw new ArgumentException(
                "New login date must be greater than old login date.", 
                nameof(lastLogin));
        }
        
        this.LastLoginAt = lastLogin;
    }
}