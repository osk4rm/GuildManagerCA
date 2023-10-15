using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Queries.GetClasses
{
    public class GetClassesQueryHandler : IRequestHandler<GetClassesQuery, ErrorOr<List<ClassResult>>>
    {
        private readonly ISpecializationRepository _specializationRepository;

        public GetClassesQueryHandler(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public async Task<ErrorOr<List<ClassResult>>> Handle(GetClassesQuery request, CancellationToken cancellationToken)
        {
            return (await _specializationRepository.GetClasses()).ToList();
        }
    }
}
