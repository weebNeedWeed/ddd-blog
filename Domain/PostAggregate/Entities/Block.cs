namespace Domain.PostAggregate.Entities;

using Domain.Common.Models;
using Domain.PostAggregate.ValueObjects;

public class Block : Entity<BlockId>
{
    private Block(
        BlockId id,
        string content,
        ushort orderNumber) 
        : base(id)
    {
        this.Content = content;
        this.OrderNumber = orderNumber;
    }
    
    public string Content { get; }
    
    public ushort OrderNumber { get; }

    public Block Create(string content, ushort orderNumber)
        => new Block(BlockId.CreateUnique(), content, orderNumber);
}