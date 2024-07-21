namespace Domain.PostAggregate;

using Domain.AdministratorAggregate.ValueObjects;
using Domain.Common.Errors;
using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.PostAggregate.Entities;
using Domain.PostAggregate.ValueObjects;
using ErrorOr;

public class Post : AggregateRoot<PostId>
{
    private List<Block> _blocks = new List<Block>();

    private Post(
        PostId id,
        string title,
        string shortDescription,
        Image thumbnailImage,
        Image coverImage,
        AdministratorId administratorId,
        DateTime createdAt,
        DateTime updatedAt,
        List<Block> blocks)
        : base(id)
    {
        this.Title = title;
        this.ShortDescription = shortDescription;
        this.CoverImage = coverImage;
        this.ThumbnailImage = thumbnailImage;
        this.AdministratorId = administratorId;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
        this._blocks.AddRange(blocks);
    }

    public string Title { get; }

    public string ShortDescription { get; }

    public Image ThumbnailImage { get; }

    public Image CoverImage { get; }

    public AdministratorId AdministratorId { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }

    public IReadOnlyList<Block> Blocks => this._blocks.AsReadOnly();

    public static ErrorOr<Post> Create(
        string title,
        string shortDescription,
        Image thumbnailImage,
        Image coverImage,
        AdministratorId administratorId,
        DateTime createdAt,
        DateTime updatedAt,
        List<Block> blocks)
    {
        // Validate the order of blocks
        if (!ValidateBlockListOrderNumber(blocks))
        {
            return Errors.Posts.InvalidOrderNumber;
        }

        return new Post(
            PostId.CreateUnique(),
            title,
            shortDescription,
            thumbnailImage,
            coverImage,
            administratorId,
            createdAt, 
            updatedAt,
            blocks);
    }

    public void UpdateBlock()
    {
        throw new NotImplementedException();
    }

    private static bool ValidateBlockListOrderNumber(List<Block> blockList)
    {
        blockList.Sort((x, y) =>
            x.OrderNumber.CompareTo(y.OrderNumber));

        for (var index = 1; index < blockList.Count; ++index)
        {
            if (blockList[index].OrderNumber == blockList[index - 1].OrderNumber)
            {
                return false;
            }
        }

        return true;
    }
}