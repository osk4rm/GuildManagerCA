﻿using GuildManagerCA.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Common.Persistence
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User?> GetUserByEmail(string email);
    }
}
