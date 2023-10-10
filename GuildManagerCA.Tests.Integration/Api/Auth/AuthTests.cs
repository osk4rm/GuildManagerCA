using FluentAssertions;
using GuildManagerCA.Application.Authentication.Commands.Register;
using GuildManagerCA.Tests.Integration.Setup;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GuildManagerCA.Tests.Integration.Api.Auth
{
    public class AuthTests : BaseIntegrationTest
    {
        public AuthTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Register_Should_ReturnOk()
        {
            //arrange
            var registerCommand = new RegisterCommand("oskar", "test", "oskarx", "oskar@test.com", "1234", "1234");
            //act
            var result = await _sender.Send(registerCommand);

            //assert
            result.Should().NotBeNull();
        }
    }
}
