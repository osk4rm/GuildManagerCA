using GuildManagerCA.Domain.CharacterAggregate;
using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Common.Persistence
{
    public interface ICharacterRepository : IAsyncRepository<Character, CharacterId>
    {
        Task<bool> CharacterWithNameExists(string name);
    }
}
