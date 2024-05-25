namespace Domain.Common.Errors;

using ErrorOr;

public partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Unauthorized(
            code: "Authentication.InvalidCredentials",
            description: "Invalid credentials.");

        public static Error DuplicatedUserName => Error.Conflict(
            code: "Authentication.DuplicatedUserName",
            description: "The given username is duplicated.");
        
        public static Error FailedToCreateUser => Error.Failure(
            code: "Authentication.FailedToCreateUser",
            description: "Failed to create user.");
    }
}