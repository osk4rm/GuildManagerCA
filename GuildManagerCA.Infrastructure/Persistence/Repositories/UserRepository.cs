using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.UserAggregate;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User, UserId>, IUserRepository
    {

        public UserRepository(GuildManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
