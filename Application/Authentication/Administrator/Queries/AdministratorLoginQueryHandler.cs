namespace Application.Authentication.Administrator.Queries;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

public class AdministratorLoginQueryHandler : IRequestHandler<AdministratorLoginQuery, ErrorOr<AdministratorLoginResult>>
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IPasswordHashingService _passwordHashingService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AdministratorLoginQueryHandler(IAdministratorRepository administratorRepository, IPasswordHashingService passwordHashingService, IJwtTokenGenerator jwtTokenGenerator)
    {
        this._administratorRepository = administratorRepository;
        this._passwordHashingService = passwordHashingService;
        this._jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AdministratorLoginResult>> Handle(AdministratorLoginQuery query, CancellationToken cancellationToken)
    {
        var admin = await this._administratorRepository.GetByUserNameAsync(query.UserName);
        if (admin is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!this._passwordHashingService.Verify(query.Password, admin.HashedPassword))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = this._jwtTokenGenerator.GenerateToken(admin);

        return new AdministratorLoginResult(admin, token);
    }
}