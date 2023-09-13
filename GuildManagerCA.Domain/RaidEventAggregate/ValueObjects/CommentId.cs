using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate.ValueObjects
{
    public class CommentId : EntityId<Guid>
    {
        private CommentId(Guid value) : base(value)
        {
        }

        public static CommentId CreateUnique() => new(Guid.NewGuid());
        public static CommentId Create(Guid value) => new(value);

    }
}
