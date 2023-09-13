using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.SpecializationAggregate.ValueObjects
{
    public class SpecializationId : AggregateRootId<Guid>
    {

        private SpecializationId(Guid value) : base(value)
        {
        }

        public static SpecializationId CreateUnique() => new(Guid.NewGuid());
        public static SpecializationId Create(Guid value) => new(value);

    }
}
