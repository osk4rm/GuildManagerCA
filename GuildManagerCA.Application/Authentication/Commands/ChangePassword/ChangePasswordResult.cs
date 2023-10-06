using GuildManagerCA.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Authentication.Commands.ChangePassword
{
    public record ChangePasswordResult(string Email, string PasswordHash);

}
