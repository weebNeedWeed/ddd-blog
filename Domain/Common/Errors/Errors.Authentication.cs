namespace Domain.Common.Errors;

using ErrorOr;

public partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Unauthorized(
            code: "Authentication.InvalidCredentials",
            description: "Invalid credentials.");
    }
}