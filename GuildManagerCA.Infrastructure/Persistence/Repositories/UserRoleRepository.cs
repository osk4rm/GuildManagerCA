using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.UserRoleAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly GuildManagerDbContext _dbContext;

        public UserRoleRepository(GuildManagerDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddRole(UserRole role)
        {
            _dbContext.UserRoles.Add(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserRole?> GetRoleByName(string name)
        {
            return await _dbContext.UserRoles.SingleOrDefaultAsync(r=>r.Name == name);
        }
    }
}
