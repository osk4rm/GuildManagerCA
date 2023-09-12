using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.CharacterAggregate.ValueObjects
{
    public class CharacterId : ValueObject
    {
        public Guid Value { get; }

        private CharacterId(Guid value)
        {
            Value = value;
        }

        public static CharacterId CreateUnique() => new(Guid.NewGuid());
        public static CharacterId Create(Guid value) => new(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
