using Domain.AuthorAggregate.ValueObjects;
using Domain.Common.Models;
using Domain.PostAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;

namespace Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private List<PostId> _readPostIds = new();

    public AuthorId? AuthorId { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public IReadOnlyList<PostId> ReadPostIds => _readPostIds.AsReadOnly();

    private User(
        UserId id,
        string userName,
        string email,
        string password) : base(id)
    {
        UserName = userName;
        Email = email;
        Password = password;
        AuthorId = null;
    }

    public static User Create(
        string username,
        string email,
        string password)
    {
        return new(
            UserId.CreateUnique(),
            username,
            email,
            password);
    }
}
