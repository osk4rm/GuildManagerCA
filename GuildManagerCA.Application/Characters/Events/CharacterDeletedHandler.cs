using GuildManagerCA.Domain.CharacterAggregate.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Events
{
    internal sealed class CharacterDeletedHandler : INotificationHandler<CharacterDeleted>
    {
        public Task Handle(CharacterDeleted notification, CancellationToken cancellationToken)
        {
            //todo logic

            throw new NotImplementedException();
        }
    }
}
