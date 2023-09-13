using GuildManagerCA.Domain.CharacterAggregate.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Events
{
    public class CharacterCreatedHandler : INotificationHandler<CharacterCreated>
    {
        public Task Handle(CharacterCreated notification, CancellationToken cancellationToken)
        {
            //TODO add handler logic
            throw new NotImplementedException();
        }
    }
}
