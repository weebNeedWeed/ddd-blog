namespace Application.Authentication.Administrator.Queries;

using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

public class AdministratorLoginQueryHandler : IRequestHandler<AdministratorLoginQuery, ErrorOr<AdministratorLoginResult>>
{
    private readonly IAdministratorRepository _administratorRepository;

    public AdministratorLoginQueryHandler(IAdministratorRepository administratorRepository)
    {
        this._administratorRepository = administratorRepository;
    }

    public async Task<ErrorOr<AdministratorLoginResult>> Handle(AdministratorLoginQuery query, CancellationToken cancellationToken)
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

        return new AdministratorLoginResult(admin, "token");
    }
}