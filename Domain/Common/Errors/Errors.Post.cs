namespace Domain.Common.Errors;

using ErrorOr;

public partial class Errors
{
    public static class Post
    {
        public static Error InvalidOrderNumber => Error.Conflict(
            code: "Post.InvalidOrderNumber", 
            description: "One or more blocks have invalid order number.");
    }
}