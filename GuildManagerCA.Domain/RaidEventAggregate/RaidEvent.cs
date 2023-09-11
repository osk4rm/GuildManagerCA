using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.RaidEventAggregate.Enum;
using GuildManagerCA.Domain.RaidEventAggregate.ValueObjects;
using GuildManagerCA.Domain.RaidEventAttendanceAggregate.ValueObjects;
using GuildManagerCA.Domain.RaidLocationAggregate.ValueObjects;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate
{
    public class RaidEvent : AggregateRoot<RaidEventId>
    {
        private readonly List<RaidEventAttendanceId> _raidEventAttendanceIds = new();
        private readonly List<CommentId> _commentsIds = new();

        public RaidLocationId RaidLocationId { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public string? Description { get; private set; }
        public bool AutoAccept { get; private set; }
        public UserId HostId { get; private set; }
        public RaidDifficulty Difficulty { get; private set; }
        public RaidEventStatus Status { get; private set; }

        public IReadOnlyList<RaidEventAttendanceId> Attendances => _raidEventAttendanceIds.AsReadOnly();
        public IReadOnlyList<CommentId> Comments => _commentsIds.AsReadOnly();

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
    }
}
