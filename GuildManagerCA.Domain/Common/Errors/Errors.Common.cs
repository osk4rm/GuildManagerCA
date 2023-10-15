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
        public static partial class Common
        {
            public static Error RepositoryDelete =>
                Error.Validation(code: "Common.RepositoryDelete", description: "Error deleting an entity");

            public static Error RepositoryUpdate =>
                Error.Validation(code: "Common.RepositoryDelete", description: "Error updating an entity");
            
        }
    }
}
