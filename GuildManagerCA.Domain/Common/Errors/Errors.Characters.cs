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
        public static class Characters
        {
            public static Error InvalidCharacterId =>
                Error.Validation(code: "Character.InvalidCharacterId", description: "Invalid Character ID");

            public static Error UpdateFailed =>
                Error.Failure(code: "Character.UpdateFailed", description: "Repository failed to update an entity.");

            public static Error Delete =>
                Error.Failure(code: "Character.DeleteFailed", description: "Repository failed to remove an entity.");
        }
    }
}
