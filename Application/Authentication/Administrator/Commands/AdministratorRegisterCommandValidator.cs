namespace Application.Authentication.Administrator.Commands;

using FluentValidation;

public class AdministratorRegisterCommandValidator : AbstractValidator<AdministratorRegisterCommand>
{
    public AdministratorRegisterCommandValidator()
    {
        this.RuleFor(x => x.FirstName)
            .NotEmpty();
    }
}