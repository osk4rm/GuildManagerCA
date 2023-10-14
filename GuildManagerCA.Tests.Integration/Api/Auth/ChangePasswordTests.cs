using FluentAssertions;
using GuildManagerCA.Application.Authentication.Commands.ChangePassword;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using GuildManagerCA.Tests.Integration.Api.Auth.TestData;
using GuildManagerCA.Tests.Integration.Setup;

namespace GuildManagerCA.Tests.Integration.Api.Auth
{
    public class ChangePasswordTests : BaseIntegrationTest
    {
        public ChangePasswordTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task ChangePassword_ForValidInput_ReturnsCorrectResult()
        {
            //arrange
            var registeredUser = await AuthTestData.RegisterValidUser(_sender);
            ChangePasswordCommand changePasswordCommand = new(registeredUser.Value.User.Id.ToString()!, "Test123#", "Test321#", "Test321#");

            //act
            var result = await _sender.Send(changePasswordCommand);

            //assert
            result.Value.Should().NotBeNull();
            result.Value.Should().BeOfType<ChangePasswordResult>();
        }

        [Fact]
        public async Task ChangePassword_ForInvalidUserId_ReturnsValidationErrors()
        {
            //arrange
            var registeredUser = await AuthTestData.RegisterValidUser(_sender);
            ChangePasswordCommand changePasswordCommand = new("123", "Test123#", "Test321#", "Test321#");
            //act
            var result = await _sender.Send(changePasswordCommand);

            //assert
            result.Value.Should().BeNull();
            result.IsError.Should().BeTrue();
            result.Errors.Should().HaveCountGreaterThan(0);
            result.Errors.All(err => err.Type == ErrorOr.ErrorType.Validation).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(AuthTestData.GetInvalidChangePasswordData), MemberType = typeof(AuthTestData))]
        public async Task ChangePassword_ForInvalidPasswords_ReturnsValidationErrors(ChangePasswordCommand command)
        {
            //arrange
            var registeredUser = await AuthTestData.RegisterValidUser(_sender);
            ChangePasswordCommand changePasswordCommand = new(
                UserId: registeredUser.Value.User.Id.ToString()!,
                OldPassword: command.OldPassword,
                NewPassword: command.NewPassword,
                ConfirmPassword: command.ConfirmPassword);
            //act
            var result = await _sender.Send(changePasswordCommand);

            //assert
            result.Value.Should().BeNull();
            result.IsError.Should().BeTrue();
            result.Errors.Should().HaveCountGreaterThan(0);
            result.Errors.All(err => err.Type == ErrorOr.ErrorType.Validation).Should().BeTrue();
        }
    }
}
