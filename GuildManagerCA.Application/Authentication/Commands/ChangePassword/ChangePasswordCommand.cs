using ErrorOr;
using GuildManagerCA.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Authentication.Commands.ChangePassword
{
    public record ChangePasswordCommand(string UserId, string OldPassword, string NewPassword, string ConfirmPassword) : IRequest<ErrorOr<ChangePasswordResult>>;
}
