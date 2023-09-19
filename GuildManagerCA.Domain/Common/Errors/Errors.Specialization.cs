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

            public static Error UpdateFailed =>
                Error.Validation(code: "Specialization.UpdateFailed", description: "Repository failed to update an entity.");
        }
    }
}
