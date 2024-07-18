namespace Infrastructure.Common.Mapping;

using Domain.AdministratorAggregate;
using Infrastructure.Persistence.Administrator;
using Mapster;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Administrator, AdministratorDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Roles, src => src.Roles.Select(x => x.Value));

        config.NewConfig<AdministratorDto, Administrator>()
            .MapWith(src => Administrator.Create(
                src.Id,
                src.UserName,
                src.Email,
                src.HashedPassword,
                src.FirstName,
                src.LastName,
                src.CreatedAt,
                src.LastLoginAt));
    }
}