using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.RaidEventAggregate.Enum;
using GuildManagerCA.Domain.RaidEventAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate.Entities
{
    public class RaidEventAttendance : Entity<RaidEventAttendanceId>
    {
        public CharacterId CharacterId { get; private set; }
        public AcceptanceStatus AcceptanceStatus { get; private set; }

        private RaidEventAttendance(
            CharacterId characterId,
            AcceptanceStatus acceptanceStatus,
            RaidEventAttendanceId? id = null) : base(id ?? RaidEventAttendanceId.CreateUnique())
        {
            CharacterId = characterId;
            AcceptanceStatus = acceptanceStatus;
        }

        public static RaidEventAttendance Create(
            CharacterId characterId,
            AcceptanceStatus acceptanceStatus
            )
        {
            return new RaidEventAttendance(characterId, acceptanceStatus);
        }
#pragma warning disable CS8618
        private RaidEventAttendance() { }
#pragma warning restore CS8618

    }
}
