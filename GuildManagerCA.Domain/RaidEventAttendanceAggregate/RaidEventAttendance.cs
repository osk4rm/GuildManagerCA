using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.RaidEventAggregate.ValueObjects;
using GuildManagerCA.Domain.RaidEventAttendanceAggregate.Enum;
using GuildManagerCA.Domain.RaidEventAttendanceAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAttendanceAggregate
{
    public class RaidEventAttendance : AggregateRoot<RaidEventAttendanceId>
    {
        public RaidEventId RaidEventId { get; private set; }
        public CharacterId CharacterId { get; private set; }
        public AcceptanceStatus AcceptanceStatus { get; private set; }

        private RaidEventAttendance(
            RaidEventId raidEventId, 
            CharacterId characterId,
            AcceptanceStatus acceptanceStatus,
            RaidEventAttendanceId? id = null) : base(id ?? RaidEventAttendanceId.CreateUnique())
        {
            RaidEventId = raidEventId;
            CharacterId = characterId;
            AcceptanceStatus = acceptanceStatus;
        }

        public static RaidEventAttendance Create(
            RaidEventId raidEventId,
            CharacterId characterId,
            AcceptanceStatus acceptanceStatus
            )
        {
            return new RaidEventAttendance(raidEventId, characterId, acceptanceStatus);
        }
    }
}
