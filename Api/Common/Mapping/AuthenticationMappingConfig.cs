namespace Api.Common.Mapping;

using Application.Authentication.Administrator.Commands;
using Application.Authentication.Administrator.Queries;
using Contracts.Authentication.Administrator;
using Mapster;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<AdministratorRegisterRequest, AdministratorRegisterCommand>();
        
        config.ForType<AdministratorLoginRequest, AdministratorLoginQuery>();
    }
}