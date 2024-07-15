using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Commands.Delete
{
    public record DeleteSpecializationCommand(string Id) : IRequest<ErrorOr<bool>>;
    
    
}
