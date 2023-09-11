using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.CharacterClass.ValueObjects
{
    public class ClassSpecializationId : ValueObject
    {
        public Guid Value { get; private set; }
        private ClassSpecializationId(Guid value)
        {
            Value = value;
        }

        public static ClassSpecializationId CreateUnique() => new(Guid.NewGuid());
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
