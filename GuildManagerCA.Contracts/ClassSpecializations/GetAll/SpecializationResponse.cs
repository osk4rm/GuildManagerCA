using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Contracts.ClassSpecializations.GetAll
{
    public record SpecializationResponse(
        string Name,
        string ImageUrl,
        string SpecializationRole,
        string ClassName,
        string ClassImageUrl,
        bool IsActive
        );
}
