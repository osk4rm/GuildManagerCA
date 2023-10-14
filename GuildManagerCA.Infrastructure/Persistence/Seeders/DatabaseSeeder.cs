using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.UserRoleAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence.Seeders
{
    public class DatabaseSeeder
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public DatabaseSeeder(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task Seed()
        {
            UserRole defaultRole = UserRole.Create("Registered");

            await _userRoleRepository.AddRole(defaultRole);
        }
    }
}
