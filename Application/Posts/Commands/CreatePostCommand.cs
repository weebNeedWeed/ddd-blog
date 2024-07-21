namespace Application.Posts.Commands;

using Domain.AdministratorAggregate.ValueObjects;
using Microsoft.AspNetCore.Http;

public record CreatePostCommand(
    string Title,
    string ShortDescription, 
    IFormFile CoverImageUrl,
    IFormFile ThumbnailImageUrl,
    AdministratorId AdministratorId, 
    List<CreateBlockCommand> CreateBlockCommands);