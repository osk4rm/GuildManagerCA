using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.Common.Models
{
    public abstract class AggregateRootId<TId> : EntityId<TId>
    {
        protected AggregateRootId(TId value) : base(value)
        {
        }
    }
}
