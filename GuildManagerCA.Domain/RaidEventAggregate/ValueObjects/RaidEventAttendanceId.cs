using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate.ValueObjects
{
    public class RaidEventAttendanceId : EntityId<Guid>
    {
        private RaidEventAttendanceId(Guid value) : base(value)
        {
        }

        public static RaidEventAttendanceId CreateUnique() => new(Guid.NewGuid());
        public static RaidEventAttendanceId Create(Guid value) => new(value);
    }
}
