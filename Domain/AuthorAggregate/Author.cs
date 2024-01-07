using Domain.AuthorAggregate.ValueObjects;
using Domain.Common.Models;

namespace Domain.AuthorAggregate;

public sealed class Author : AggregateRoot<AuthorId>
{
    public Author(AuthorId id) : base(id)
    {
    }
}
