using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.CharacterClass.ValueObjects
{
    public class CharacterClassId : ValueObject
    {
        public Guid Value { get; private set; }

        private CharacterClassId(Guid value)
        {
            Value = value;
        }

        public static CharacterClassId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
