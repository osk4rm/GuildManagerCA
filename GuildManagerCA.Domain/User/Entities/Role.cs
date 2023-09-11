using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.User.Entities
{
    public sealed class Role : Entity<RoleId>
    {
        public string Name { get; }
        public string Description { get; }

        private Role(string name, string description) : base(RoleId.CreateUnique())
        {
            Name = name;
            Description = description;
        }

        public static Role Create(string name, string description)
        {
            return new(name, description);
        }
    }
}
