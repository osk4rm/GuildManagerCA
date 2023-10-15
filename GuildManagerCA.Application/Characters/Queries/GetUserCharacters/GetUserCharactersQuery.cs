using ErrorOr;
using GuildManagerCA.Domain.CharacterAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Queries.GetUserCharacters
{
    public record GetUserCharactersQuery : IRequest<ErrorOr<List<Character>>>;
}
