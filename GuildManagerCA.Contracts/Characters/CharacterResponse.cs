using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Contracts.Characters
{
    public record CharacterResponse(
        string Name,
        double ItemLevel,
        UserId UserId,
        List<SpecializationId> specializationIds);
}
