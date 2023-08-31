using GuildManagerCA.Application.Authentication.Commands.Register;
using GuildManagerCA.Application.Authentication.Common;
using GuildManagerCA.Application.Authentication.Queries.Login;
using GuildManagerCA.Contracts.Authentication;
using Mapster;

namespace GuildManagerCA.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
