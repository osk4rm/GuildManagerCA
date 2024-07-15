using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.Common.Errors;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Commands.Delete
{
    public class DeleteSpecializationCommandHandler : IRequestHandler<DeleteSpecializationCommand, ErrorOr<bool>>
    {
        private readonly ISpecializationRepository _specializationRepository;

        public DeleteSpecializationCommandHandler(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public async Task<ErrorOr<bool>> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specializationId = SpecializationId.Create(request.Id);

            if (specializationId.IsError)
                return Errors.Specialization.InvalidSpecializationId;

            try
            {
                var specialization = await _specializationRepository.GetByIdAsync(specializationId.Value);
                await _specializationRepository.DeleteAsync(specialization!);

                return true;
            }
            catch(Exception)
            {
                return Errors.Common.RepositoryDelete;
            }
        }
    }
}
