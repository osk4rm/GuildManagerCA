using ErrorOr;
using GuildManagerCA.Application.Common.Authentication;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.CharacterAggregate;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using GuildManagerCA.Domain.Common.Errors;
using MediatR;

namespace GuildManagerCA.Application.Characters.Queries.GetUserCharacters
{
    public class GetUserCharactersQueryHandler : IRequestHandler<GetUserCharactersQuery, ErrorOr<List<Character>>>
    {
        private readonly IUserContextService _userContextService;
        private readonly ICharacterRepository _characterRepository;

        public GetUserCharactersQueryHandler(IUserContextService userContextService, ICharacterRepository characterRepository)
        {
            _userContextService = userContextService;
            _characterRepository = characterRepository;
        }
        public async Task<ErrorOr<List<Character>>> Handle(GetUserCharactersQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContextService.Id is null ? null : UserId.Create(_userContextService.Id.Value);
            if(userId is null)
            {
                return Errors.Authentication.UserContextIdNull;
            }

            return (await _characterRepository.GetAsync(c => c.UserId == userId)).ToList();
        }
    }
}
