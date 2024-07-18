namespace Api.Endpoints;

using ErrorOr;

public static class CustomResults
{
    public static IResult Errors(List<Error> errors)
    {
        if (!errors.Any())
        {
            return Results.Problem(
                title: "An error occured during processing your request.",
                statusCode: StatusCodes.Status500InternalServerError);
        }

        if (errors.All(x => x.Type.Equals(ErrorType.Validation)))
        {
            return ValidationErrors(errors);
        }
        
        var firstError = errors.First();
        return Errors(firstError);
    }

    private static IResult Errors(Error error)
    {
        var (title, statusCode) = error.Type switch
        {
            ErrorType.Unauthorized => (error.Description, StatusCodes.Status401Unauthorized),
            ErrorType.Conflict => (error.Description, StatusCodes.Status409Conflict),
            _ => ("An error occured during processing your request.", StatusCodes.Status500InternalServerError),
        };

        return Results.Problem(title: title, statusCode: statusCode);
    }

    private static IResult ValidationErrors(List<Error> errors)
    {
        var errorDict = new Dictionary<string, string[]>();
        foreach (var error in errors)
        {
            errorDict.Add(error.Code, [error.Description]);
        }
        
        return Results.ValidationProblem(errorDict);
    }
}