using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.SpecializationAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Queries.GetByClassName
{
    public class GetSpecializationByClassNameQueryHandler : IRequestHandler<GetSpecializationByClassNameQuery, ErrorOr<List<Specialization>>>
    {
        private readonly ISpecializationRepository _specializationRepository;

        public GetSpecializationByClassNameQueryHandler(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public async Task<ErrorOr<List<Specialization>>> Handle(GetSpecializationByClassNameQuery request, CancellationToken cancellationToken)
        {
            return await _specializationRepository.GetByClassName(request.className);
        }
    }
}
