using ErrorOr;
using GuildManagerCA.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string NickName,
        string Email,
        string Password,
        string ConfirmPassword) : IRequest<ErrorOr<AuthenticationResult>>;
}
