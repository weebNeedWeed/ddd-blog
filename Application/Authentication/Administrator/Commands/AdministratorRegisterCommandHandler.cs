namespace Application.Authentication.Administrator.Commands;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Domain.AdministratorAggregate;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

public class AdministratorRegisterCommandHandler 
    : IRequestHandler<AdministratorRegisterCommand, ErrorOr<AdministratorRegisterResult>>
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IPasswordHashingService _passwordHashingService;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AdministratorRegisterCommandHandler(
        IAdministratorRepository administratorRepository, 
        IPasswordHashingService passwordHashingService, 
        IDateTimeProvider dateTimeProvider)
    {
        this._administratorRepository = administratorRepository;
        this._passwordHashingService = passwordHashingService;
        this._dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<AdministratorRegisterResult>> Handle(
        AdministratorRegisterCommand command, 
        CancellationToken cancellationToken)
    {
        var admin = await this._administratorRepository.GetByUserNameAsync(command.UserName);
        if (admin is not null)
        {
            return Errors.Authentication.DuplicatedUserName;
        }

        var hashed = this._passwordHashingService.HashPassword(command.Password);

        var newAdmin = Administrator.Create(
            userName: command.UserName,
            email: command.Email,
            firstName: command.FirstName,
            lastName: command.LastName,
            hashedPassword: hashed,
            createdAt: this._dateTimeProvider.UtcNow,
            lastLoginAt: null);

        var isSucceed = await this._administratorRepository.AddAsync(newAdmin);

        return new AdministratorRegisterResult(IsSucceeded: isSucceed);
    }
}