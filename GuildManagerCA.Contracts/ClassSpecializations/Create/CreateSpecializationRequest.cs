using GuildManagerCA.Domain.SpecializationAggregate.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Contracts.ClassSpecializations.Create
{
    public record CreateSpecializationRequest
    (
        string Name,
        string ClassName,
        string ClassImageUrl,
        string ImageUrl,
        SpecializationRole SpecializationRole
    );
}
