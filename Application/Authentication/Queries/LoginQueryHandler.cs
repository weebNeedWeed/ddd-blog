namespace Application.Authentication.Queries;

using Application.Common.Persistence;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<LoginResult>>
{
    private readonly IAdministratorRepository _administratorRepository;

    public LoginQueryHandler(IAdministratorRepository administratorRepository)
    {
        this._administratorRepository = administratorRepository;
    }

    public async Task<ErrorOr<LoginResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var admin = await this._administratorRepository.GetByEmailAsync(query.Email);
        if (admin is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!admin.HashedPassword.Equals(query.Password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        return new LoginResult(admin, "token");
    }
}