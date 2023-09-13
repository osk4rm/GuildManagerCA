using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate.ValueObjects
{
    public class RaidEventId : AggregateRootId<Guid>
    {
        private RaidEventId(Guid value) : base(value)
        {
        }

        public static RaidEventId CreateUnique() => new(Guid.NewGuid());
        public static RaidEventId Create(Guid value) => new(value);

    }
}
