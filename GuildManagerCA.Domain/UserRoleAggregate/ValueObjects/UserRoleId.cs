using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.UserRoleAggregate.ValueObjects
{
    public sealed class UserRoleId : ValueObject
    {
        public Guid Value { get; }

        private UserRoleId(Guid value)
        {
            Value = value;
        }

        public static UserRoleId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
