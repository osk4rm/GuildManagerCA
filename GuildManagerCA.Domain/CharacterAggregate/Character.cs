using GuildManagerCA.Domain.CharacterAggregate.Events;
using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.RaidEventAggregate.ValueObjects;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.CharacterAggregate
{
    public class Character : AggregateRoot<CharacterId, Guid>
    {
        private readonly List<RaidEventId> _raidEventIds = new();
        private readonly List<SpecializationId> _specializationIds = new();

        public string Name { get; private set; }
        public double ItemLevel { get; private set; }
        public UserId UserId { get; private set; }

        public IReadOnlyList<SpecializationId> SpecializationIds => _specializationIds.AsReadOnly();
        public IReadOnlyList<RaidEventId> RaidEventIds => _raidEventIds.AsReadOnly();

        private Character(
            string name,
            double itemLevel,
            UserId userId,
            List<SpecializationId> specializationIds,
            CharacterId? id = null) : base(id ?? CharacterId.CreateUnique())
        {
            Name = name;
            ItemLevel = itemLevel;
            UserId = userId;
            _specializationIds = specializationIds;
        }

        public static Character Create(
            string name,
            double itemLevel,
            UserId userId,
            List<SpecializationId> specializationIds
            )
        {
            var character = new Character(name, itemLevel, userId, specializationIds);
            character.AddDomainEvent(new CharacterCreated(character));
            return character;
        }

        
#pragma warning disable CS8618
        private Character() { }
#pragma warning restore CS8618
    }
}
