using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.SpecializationAggregate.ValueObjects
{
    public class SpecializationId : ValueObject
    {
        public Guid Value { get; }

        private SpecializationId(Guid value)
        {
            Value = value;
        }

        public static SpecializationId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
