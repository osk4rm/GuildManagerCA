using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.SpecializationAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Queries
{
    public class GetAllSpecializationsQueryHandler : IRequestHandler<GetAllSpecializationsQuery, ErrorOr<List<Specialization>>>
    {
        private readonly ISpecializationRepository _specializationRepository;

        public GetAllSpecializationsQueryHandler(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public async Task<ErrorOr<List<Specialization>>> Handle(GetAllSpecializationsQuery request, CancellationToken cancellationToken)
        {
            if (request.OnlyActive)
            {
                return await _specializationRepository.GetAllActiveAsync();
            }

            return await _specializationRepository.GetAllAsync();
        }
    }
}
