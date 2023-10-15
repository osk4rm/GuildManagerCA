using ErrorOr;
using GuildManagerCA.Domain.CharacterAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Queries.GetAllCharacters
{
    public record GetAllCharactersQuery : IRequest<ErrorOr<List<Character>>>;
}
