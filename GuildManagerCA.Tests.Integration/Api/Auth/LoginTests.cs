using FluentAssertions;
using GuildManagerCA.Application.Authentication.Common;
using GuildManagerCA.Application.Authentication.Queries.Login;
using GuildManagerCA.Tests.Integration.Api.Auth.TestData;
using GuildManagerCA.Tests.Integration.Setup;

namespace GuildManagerCA.Tests.Integration.Api.Auth
{
    public class LoginTests : BaseIntegrationTest
    {
        public LoginTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Login_ForValidInput_ReturnsAuthenticationResult()
        {
            //arrange
            await AuthTestData.RegisterValidUser(_sender);
            LoginQuery loginQuery = new("oskar@test.com", "Test123#");

            //act
            var result = await _sender.Send(loginQuery);

            //assert
            result.Value.Should().NotBeNull();
            result.Value.Should().BeOfType(typeof(AuthenticationResult));
        }

        [Fact]
        public async Task Login_ForNonExistingEmail_ReturnsError()
        {
            //arrange
            LoginQuery loginQuery = new("oskar@test.com", "Test123#");

            //act
            var result = await _sender.Send(loginQuery);

            //assert
            result.Value.Should().BeNull();
            result.Errors.Should().HaveCount(1);
            result.FirstError.Should().Be(Domain.Common.Errors.Errors.Authentication.InvalidCredentials);
        }

        [Fact]
        public async Task Login_ForIncorrectPassword_ReturnsError()
        {
            //arrange
            await AuthTestData.RegisterValidUser(_sender);
            LoginQuery loginQuery = new("oskar@test.com", "Test123!");

            //act
            var result = await _sender.Send(loginQuery);

            //assert
            result.Value.Should().BeNull();
            result.Errors.Should().HaveCount(1);
            result.FirstError.Should().Be(Domain.Common.Errors.Errors.Authentication.InvalidCredentials);
        }
    }
}
