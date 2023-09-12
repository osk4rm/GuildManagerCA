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
        private RaidLocationId(Guid value) //: base(value)
        {
            Value = value;
        }

        public static RaidLocationId CreateUnique() => new(Guid.NewGuid());
        public static RaidLocationId Create(Guid value) => new(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
#pragma warning disable CS8618
        private RaidLocationId() { }
#pragma warning restore CS8618
    }
}
