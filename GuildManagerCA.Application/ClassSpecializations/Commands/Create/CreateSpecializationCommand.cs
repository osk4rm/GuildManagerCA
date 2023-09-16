using ErrorOr;
using GuildManagerCA.Domain.SpecializationAggregate.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Commands.Create
{
    public record CreateSpecializationCommand
        (
        string Name,
        string ClassName,
        string ClassImageUrl,
        string ImageUrl,
        SpecializationRole SpecializationRole
        ) :IRequest<ErrorOr<CreateSpecializationResult>>;
}
