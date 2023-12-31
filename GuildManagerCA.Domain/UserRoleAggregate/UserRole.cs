﻿using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.UserRoleAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.UserRoleAggregate
{
    public sealed class UserRole : AggregateRoot<UserRoleId, Guid>
    {
        public string Name { get; private set; }

        public UserRole(string name, UserRoleId? id = null) : base(id ?? UserRoleId.CreateUnique())
        {
            Name = name;
        }

        public static UserRole Create(string name) => new(name);

#pragma warning disable CS8618
        private UserRole() { }
#pragma warning restore CS8618
    }
}
