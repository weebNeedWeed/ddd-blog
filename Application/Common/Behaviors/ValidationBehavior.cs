namespace Application.Common.Behaviors;

using ErrorOr;
using FluentValidation;
using MediatR;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        this._validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (this._validator is null)
        {
            return await next();
        }

        var validationResult = await this._validator.ValidateAsync(request, cancellationToken);
        if (validationResult is null || validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors.ConvertAll(
            x => Error.Validation(
                code: x.PropertyName,
                description: x.ErrorMessage));

        return (dynamic)errors;
    }
}