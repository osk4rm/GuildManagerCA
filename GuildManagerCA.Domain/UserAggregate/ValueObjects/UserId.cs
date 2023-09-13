using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.UserAggregate.ValueObjects
{
    public sealed class UserId : AggregateRootId<Guid>
    {
        private UserId(Guid value) : base(value)
        {
        }

        public static UserId CreateUnique() => new(Guid.NewGuid());
        public static UserId Create(Guid value) => new(value);

    }
}
