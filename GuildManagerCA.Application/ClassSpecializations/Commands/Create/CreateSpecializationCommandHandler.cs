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

namespace GuildManagerCA.Application.ClassSpecializations.Commands.Create
{
    public class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, ErrorOr<CreateSpecializationResult>>
    {
        private readonly ISpecializationRepository _specializationRepository;

        public CreateSpecializationCommandHandler(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public async Task<ErrorOr<CreateSpecializationResult>> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = Specialization.Create(
                name: request.Name,
                imageUrl: new Uri(request.ImageUrl),
                characterClass: CharacterClass.Create(request.ClassName, new Uri(request.ClassImageUrl)),
                specializationRole: request.SpecializationRole,
                isActive: true
                );

            await _specializationRepository.CreateAsync(specialization);

            return new CreateSpecializationResult(specialization.Id.Value.ToString());
        }
    }
}
