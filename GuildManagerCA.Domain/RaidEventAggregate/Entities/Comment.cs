using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.RaidEventAggregate.ValueObjects;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidEventAggregate.Entities
{
    public class Comment : Entity<CommentId>
    {
        public UserId Author { get; private set; }
        public string Message { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime? ModifiedDateTime { get; private set; }

        private Comment(
            UserId userId,
            string message,
            CommentId? id = null) : base(id ?? CommentId.CreateUnique())
        {
            Author = userId;
            Message = message;
            CreatedDateTime = DateTime.UtcNow;
        }

        public static Comment Create(
            UserId userId,
            string message
            )
        {
            return new Comment(userId, message);
        }
    }
}
