using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.CharacterAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Queries
{
    public class GetAllCharactersQueryHandler : IRequestHandler<GetAllCharactersQuery, ErrorOr<List<Character>>>
    {
        private readonly ICharacterRepository _characterRepository;

        public GetAllCharactersQueryHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public async Task<ErrorOr<List<Character>>> Handle(GetAllCharactersQuery request, CancellationToken cancellationToken)
        {
            return (await _characterRepository.GetAllAsync()).ToList();
        }
    }
}
