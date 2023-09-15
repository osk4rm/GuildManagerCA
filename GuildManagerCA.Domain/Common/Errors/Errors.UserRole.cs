using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class UserRole
        {
            public static Error DefaultRoleNotSet => Error.NotFound(code: "UserRole.DefaultRoleNotSet", description: "Couldn't find default role");
        }
    }
}
