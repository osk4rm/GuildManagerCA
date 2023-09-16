using ErrorOr;
using GuildManagerCA.Domain.SpecializationAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Queries.GetAll
{
    public record GetAllSpecializationsQuery(bool OnlyActive = false) : IRequest<ErrorOr<List<Specialization>>>;
}
