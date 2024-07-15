using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildManagerCA.Domain.Common.Errors;

namespace GuildManagerCA.Application.Characters.Commands.Delete
{
    internal sealed class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand, ErrorOr<bool>>
    {
        private readonly ICharacterRepository _characterRepository;

        public DeleteCharacterCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            var characterId = CharacterId.Create(request.Id);

            if (characterId.IsError)
                return Errors.Characters.InvalidCharacterId;

            try
            {
                var specialization = await _characterRepository.GetByIdAsync(characterId.Value);
                await _characterRepository.DeleteAsync(specialization!);

                return true;
            }
            catch (Exception)
            {
                return Errors.Common.RepositoryDelete;
            }
        }
    }
}
