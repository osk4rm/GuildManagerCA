using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Commands.Delete
{
    public record DeleteCharacterCommand(string Id) : IRequest<ErrorOr<bool>>;
}
