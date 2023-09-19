using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.Common.Errors;
using GuildManagerCA.Domain.SpecializationAggregate;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Commands.Update
{
    public class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand, ErrorOr<Specialization>>
    {
        private readonly ISpecializationRepository _specializationRepository;

        public UpdateSpecializationCommandHandler(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public async Task<ErrorOr<Specialization>> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specId = SpecializationId.Create(request.Id);
            if (specId.IsError)
            {
                return Errors.Specialization.InvalidSpecializationId;
            }
            var updatedSpec = await _specializationRepository.UpdateSpecialization(specId.Value, request.Name, request.ImageUrl);

            if(updatedSpec is null)
            {
                return Errors.Specialization.UpdateFailed;
            }

            return updatedSpec;
        }
    }
}
