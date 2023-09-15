using GuildManagerCA.Domain.UserRoleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Common.Persistence
{
    public interface IUserRoleRepository
    {
        Task AddRole(UserRole role);
        Task<UserRole?> GetRoleByName(string name);
    }
}
