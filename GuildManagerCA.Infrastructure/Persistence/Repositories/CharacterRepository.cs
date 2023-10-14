using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.CharacterAggregate;
using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence.Repositories
{
    public class CharacterRepository : RepositoryBase<Character, CharacterId>, ICharacterRepository
    {
        public CharacterRepository(GuildManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
