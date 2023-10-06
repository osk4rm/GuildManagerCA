using GuildManagerCA.Domain.UserAggregate;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Common.Persistence
{
    public interface IUserRepository : IAsyncRepository<User, UserId>
    {
        Task<User?> GetUserByEmail(string email);
    }
}
