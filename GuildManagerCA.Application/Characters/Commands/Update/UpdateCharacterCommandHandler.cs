using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.CharacterAggregate;
using GuildManagerCA.Domain.Common.Errors;
using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Commands.Update
{
    public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand, ErrorOr<Character>>
    {
        private readonly ICharacterRepository _characterRepository;

        public UpdateCharacterCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public async Task<ErrorOr<Character>> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
        {
            var characterId = CharacterId.Create(request.Id);

            if (characterId.IsError)
                return Errors.Characters.InvalidCharacterId;

            var entity = await _characterRepository.GetByIdAsync(characterId.Value);

            if (entity is null)
                return Errors.Characters.InvalidCharacterId;

            entity = Character.Update(request.Name, request.ItemLevel, request.SpecializationIds, characterId.Value, entity.UserId);

            try
            {
                await _characterRepository.UpdateAsync(entity);
            }
            catch (Exception)
            {
                return Errors.Characters.UpdateFailed;
            }

            return entity;
        }
    }
}
