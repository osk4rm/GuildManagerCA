using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidLocationAggregate.ValueObjects
{
    public class RaidLocationId : AggregateRootId<Guid>
    {
        private RaidLocationId(Guid value) : base(value)
        {
        }

        public static RaidLocationId CreateUnique() => new(Guid.NewGuid());
        public static RaidLocationId Create(Guid value) => new(value);

    }
}
