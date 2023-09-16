using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.SpecializationAggregate;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Queries.GetById
{
    public class GetSpecializationByIdQueryHandler : IRequestHandler<GetSpecializationByIdQuery, ErrorOr<Specialization?>>
    {
        private readonly ISpecializationRepository _specializationRepository;

        public GetSpecializationByIdQueryHandler(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public async Task<ErrorOr<Specialization?>> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
        {
            var createSpecIdResult = SpecializationId.Create(request.Id);
            if (createSpecIdResult.IsError)
            {
                return createSpecIdResult.FirstError;
            }
            var specialization = await _specializationRepository.GetById(createSpecIdResult.Value);

            return specialization;
        }
    }
}
