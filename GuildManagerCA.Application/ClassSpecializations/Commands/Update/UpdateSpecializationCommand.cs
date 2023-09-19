using ErrorOr;
using GuildManagerCA.Domain.SpecializationAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Commands.Update
{
    public record UpdateSpecializationCommand(string Id, string Name, string ImageUrl) : IRequest<ErrorOr<Specialization>>;

}
