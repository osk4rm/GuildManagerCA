using ErrorOr;
using GuildManagerCA.Domain.CharacterAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Commands.Create
{
    public record CreateCharacterCommand(string Name, double ItemLevel, IEnumerable<Guid> SpecializationIds) : IRequest<ErrorOr<Character>>;
}
