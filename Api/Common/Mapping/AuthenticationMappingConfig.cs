namespace Api.Common.Mapping;

using Application.Authentication.Administrator.Commands;
using Contracts.Authentication.Administrator;
using Mapster;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<AdministratorRegisterRequest, AdministratorRegisterCommand>();
    }
}