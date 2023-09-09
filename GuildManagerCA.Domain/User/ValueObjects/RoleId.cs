using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.User.ValueObjects
{
    public sealed class RoleId : ValueObject
    {
        public Guid Value { get; }

        private RoleId(Guid value)
        {
            Value = value;
        }

        public static RoleId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
