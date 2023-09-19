using ErrorOr;
using GuildManagerCA.Domain.SpecializationAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Commands.SetActivity
{
    public record SetActivityCommand(string Id, bool IsActive) : IRequest<ErrorOr<Specialization>>;

}
