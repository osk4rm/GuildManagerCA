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
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(code: "Auth.InvalidCredentials", description: "Invalid credentials.");
            public static Error UserContextIdNull =>
                Error.Validation(code: "Auth.UserContextIdNull", description: "Couldn't resolve user id from the token.");
        }
    }
}
