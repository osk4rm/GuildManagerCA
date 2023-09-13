using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.CharacterAggregate.ValueObjects
{
    public class CharacterId : AggregateRootId<Guid>
    {
        private CharacterId(Guid value) : base(value)
        {
        }

        public static CharacterId CreateUnique() => new(Guid.NewGuid());
        public static CharacterId Create(Guid value) => new(value);

    }
}
