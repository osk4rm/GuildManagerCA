using ErrorOr;
using GuildManagerCA.Application.Common.Authentication;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.CharacterAggregate;
using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Commands.Create
{
    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, ErrorOr<Character>>
    {
        private readonly IUserContextService _userContextService;
        private readonly ICharacterRepository _characterRepository;

        public CreateCharacterCommandHandler(IUserContextService userContextService, ICharacterRepository characterRepository)
        {
            _userContextService = userContextService;
            _characterRepository = characterRepository;
        }
        public async Task<ErrorOr<Character>> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            var character = Character.Create(
                request.Name,
                request.ItemLevel,
                UserId.Create(_userContextService.Id!.Value),
                request.SpecializationIds.Select(sid => SpecializationId.Create(sid)).ToList());

            return await _characterRepository.AddAsync(character);
        }


    }
}
