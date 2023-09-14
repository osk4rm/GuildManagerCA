using GuildManagerCA.Domain.Common.Models.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.CharacterAggregate.Events
{
    public record CharacterCreated(Character Character) : IDomainEvent
    {
    }
}
