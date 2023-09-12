using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate.ValueObjects
{
    public class CommentId : ValueObject
    {
        public Guid Value { get; }

        private CommentId(Guid value)
        {
            Value = value;
        }

        public static CommentId CreateUnique() => new(Guid.NewGuid());
        public static CommentId Create(Guid value) => new(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
