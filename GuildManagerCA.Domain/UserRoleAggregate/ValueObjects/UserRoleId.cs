using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.UserRoleAggregate.ValueObjects
{
    public sealed class UserRoleId : AggregateRootId<Guid>
    {

        private UserRoleId(Guid value) : base(value)
        {
        }

        public static UserRoleId CreateUnique() => new(Guid.NewGuid());
        public static UserRoleId Create(Guid value) => new(value);

    }
}
