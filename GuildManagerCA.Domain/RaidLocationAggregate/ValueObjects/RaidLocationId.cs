using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidLocationAggregate.ValueObjects
{
    public class RaidLocationId : ValueObject
    {
        public Guid Value { get; }

        public RaidLocationId(Guid value)
        {
            Value = value;
        }

        public static RaidLocationId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
