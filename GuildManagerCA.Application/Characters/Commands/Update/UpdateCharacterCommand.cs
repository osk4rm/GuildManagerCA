using ErrorOr;
using GuildManagerCA.Domain.CharacterAggregate;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Commands.Update
{
    public record UpdateCharacterCommand(string Id, string Name, double ItemLevel, List<SpecializationId> SpecializationIds) : IRequest<ErrorOr<Character>>;
}