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
        public static class Specialization
        {
            public static Error InvalidSpecializationId =>
                Error.Validation(code: "Specialization.InvalidSpecializationId", description: "Invalid Specialization ID");
        }
    }
}
