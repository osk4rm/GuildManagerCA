using ErrorOr;
using FluentAssertions;
using GuildManagerCA.Application.Authentication.Commands.Register;
using GuildManagerCA.Application.Authentication.Common;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Tests.Integration.Api.Auth.TestData;
using GuildManagerCA.Tests.Integration.Api.Specialization.TestData;
using GuildManagerCA.Tests.Integration.Setup;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GuildManagerCA.Tests.Integration.Api.Auth
{
    public class RegisterTests : BaseIntegrationTest
    {
        public RegisterTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
            
        }

        [Fact]
        public async Task Register_ForValidRegistrationData_ReturnsAuthenticationResult()
        {
            //act
            var result = await AuthTestData.RegisterValidUser(_sender);

            //assert
            result.Value.Should().BeOfType(typeof(AuthenticationResult));
        }

        [Theory]
        [MemberData(nameof(AuthTestData.GetInvalidRegistrationData), MemberType = typeof(AuthTestData))]
        public async Task Register_ForInvalidRegistrationData_ReturnsErrors(RegisterCommand registerCommand)
        {
            //act
            var result = await _sender.Send(registerCommand);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
            result.Value.Should().BeNull();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
        }

        [Fact]
        public async Task Register_ForRegisteringExistingEmailAttempt_ReturnsError()
        {
            //arrange
            await AuthTestData.RegisterValidUser(_sender);

            //act
            var sameUserRegisterAttempt = await AuthTestData.RegisterValidUser(_sender);

            //assert
            sameUserRegisterAttempt.Errors.Count.Should().Be(1);
            sameUserRegisterAttempt.Value.Should().BeNull();
            sameUserRegisterAttempt.FirstError.Type.Should().Be(ErrorType.Validation);
        }
    }
}
