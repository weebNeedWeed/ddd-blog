namespace Application.Common.Interfaces.Persistence;

using Domain.PostAggregate;
using Domain.PostAggregate.ValueObjects;

public interface IPostRepository
{
    void AddAsync(Post post);

    Post GetPostByIdAsync(PostId id);
}