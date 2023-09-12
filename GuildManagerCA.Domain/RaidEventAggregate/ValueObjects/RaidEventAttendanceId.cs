using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate.ValueObjects
{
    public class RaidEventAttendanceId : ValueObject
    {
        public Guid Value { get; }

        private RaidEventAttendanceId(Guid value)
        {
            Value = value;
        }

        public static RaidEventAttendanceId CreateUnique() => new(Guid.NewGuid());
        public static RaidEventAttendanceId Create(Guid value) => new(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
