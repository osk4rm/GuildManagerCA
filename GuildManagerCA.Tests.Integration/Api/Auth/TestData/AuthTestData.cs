using ErrorOr;
using GuildManagerCA.Application.Authentication.Commands.ChangePassword;
using GuildManagerCA.Application.Authentication.Commands.Register;
using GuildManagerCA.Application.Authentication.Common;
using GuildManagerCA.Contracts.ClassSpecializations.Create;
using GuildManagerCA.Domain.SpecializationAggregate.Enum;
using MediatR;

namespace GuildManagerCA.Tests.Integration.Api.Auth.TestData
{
    public class AuthTestData
    {
        public static IEnumerable<object[]> GetInvalidRegistrationData()
        {
            var list = new List<RegisterCommand>
            {
                //invalid email
                new RegisterCommand("john","doe","jdoe","jdoeinvalidemail","JDxzawe15@","JDxzawe15@"),
                //empty lastname
                new RegisterCommand("jack","","jsparrow","jdoe@gmail.com","JDxzawe15@","JDxzawe15@"),
                //empty firstname
                new RegisterCommand("","doe","jdoe","jdoe@gmail.com","JDxzawe15@","JDxzawe15@"),
                //insecure password
                new RegisterCommand("john","doe","jdoe","jdoe@gmail.com","xzawe15@","xzawe15@"),
                //passwords do not match
                new RegisterCommand("","doe","jdoe","jdoe@gmail.com","JDxzawe15@","JDxzawe15$"),

            };

            return list.Select(l => new object[] { l });
        }

        public static IEnumerable<object[]> GetInvalidChangePasswordData()
        {
            var list = new List<ChangePasswordCommand>
            {
                //invalid old password
                new ChangePasswordCommand("dummy", "Test124#", "Test321#", "Test321#"),
                //no special character
                new ChangePasswordCommand("dummy", "Test123#", "Test321", "Test321"),
                //no capital letter
                new ChangePasswordCommand("dummy", "Test123#", "abc3332#", "abc3332#"),
                //too short
                new ChangePasswordCommand("dummy", "Test123#", "T321#", "T321#"),
                //password and confirm password aren't matching
                new ChangePasswordCommand("dummy", "Test123#", "Test321#", "Test432#"),
                
                

            };

            return list.Select(l => new object[] { l });
        }

        public static async Task<ErrorOr<AuthenticationResult>> RegisterValidUser(ISender sender)
        {
            var registerCommand = new RegisterCommand("oskar", "lastname", "oskarx", "oskar@test.com", "Test123#", "Test123#");
            return await sender.Send(registerCommand);
        }
    }
}
