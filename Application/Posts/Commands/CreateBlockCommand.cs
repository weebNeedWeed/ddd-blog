namespace Application.Posts.Commands;

public record CreateBlockCommand(
    ushort OrderNumber, 
    string Content);