using ErrorOr;
using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.Common.Errors;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.CharacterAggregate.ValueObjects
{
    public class CharacterId : AggregateRootId<Guid>
    {
        private CharacterId(Guid value) : base(value)
        {
        }

        public static CharacterId CreateUnique() => new(Guid.NewGuid());
        public static CharacterId Create(Guid value) => new(value);
        public static ErrorOr<CharacterId> Create(string value)
        {
            if (!Guid.TryParse(value, out var guid))
            {
                return Errors.Characters.InvalidCharacterId;
            }

            return new CharacterId(guid);
        }
    }
}
