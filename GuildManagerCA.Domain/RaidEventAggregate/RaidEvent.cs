using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.RaidEventAggregate.Entities;
using GuildManagerCA.Domain.RaidEventAggregate.Enum;
using GuildManagerCA.Domain.RaidEventAggregate.ValueObjects;
using GuildManagerCA.Domain.RaidLocationAggregate.ValueObjects;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate
{
    public class RaidEvent : AggregateRoot<RaidEventId, Guid>
    {
        private readonly List<RaidEventAttendance> _raidEventAttendances = new();
        private readonly List<Comment> _comments = new();

        public RaidLocationId RaidLocationId { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public string? Description { get; private set; }
        public bool AutoAccept { get; private set; }
        public UserId HostId { get; private set; }
        public RaidDifficulty Difficulty { get; private set; }
        public RaidEventStatus Status { get; private set; }

        public IReadOnlyList<RaidEventAttendance> Attendances => _raidEventAttendances.AsReadOnly();
        public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();

        private RaidEvent(
            RaidLocationId raidLocationId,
            DateTime startDateTime, 
            DateTime endDateTime,
            bool autoAccept,
            UserId hostId,
            RaidDifficulty difficulty,
            string? description = null,
            RaidEventId? id = null) : base(id ?? RaidEventId.CreateUnique())
        {
            RaidLocationId = raidLocationId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            AutoAccept = autoAccept;
            HostId = hostId;
            Difficulty = difficulty;
            Description = description;
            Status = RaidEventStatus.Open;
        }

        public static RaidEvent Create(
            RaidLocationId raidLocationId,
            DateTime startDateTime,
            DateTime endDateTime,
            bool autoAccept,
            UserId hostId,
            RaidDifficulty raidDifficulty,
            string? description = null
            )
        {
            return new RaidEvent(raidLocationId, startDateTime, endDateTime, autoAccept, hostId, raidDifficulty, description);
        }

#pragma warning disable CS8618
        private RaidEvent() { }
#pragma warning restore CS8618
    }
}
