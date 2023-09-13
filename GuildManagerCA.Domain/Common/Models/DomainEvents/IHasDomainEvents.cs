using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.Common.Models.DomainEvents
{
    public interface IHasDomainEvents
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }

        public void ClearDomainEvents();
    }
}
