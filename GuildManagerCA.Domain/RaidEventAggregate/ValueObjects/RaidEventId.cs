using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate.ValueObjects
{
    public class RaidEventId : ValueObject
    {
        public Guid Value { get; }

        private RaidEventId(Guid value)
        {
            Value = value;
        }

        public static RaidEventId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
