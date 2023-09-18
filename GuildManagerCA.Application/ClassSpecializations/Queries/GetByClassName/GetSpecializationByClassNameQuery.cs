using ErrorOr;
using GuildManagerCA.Domain.SpecializationAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Queries.GetByClassName
{
    public record GetSpecializationByClassNameQuery(string className) : IRequest<ErrorOr<List<Specialization>>>;
   
}
