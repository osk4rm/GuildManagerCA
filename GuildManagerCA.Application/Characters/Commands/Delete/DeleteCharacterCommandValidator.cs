using FluentValidation;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Commands.Delete
{
    internal sealed class DeleteCharacterCommandValidator : AbstractValidator<DeleteCharacterCommand>
    {
        public DeleteCharacterCommandValidator(ICharacterRepository characterRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .CustomAsync(async (value, context, cancellationToken) =>
                {
                    var id = CharacterId.Create(value);

                    if (!id.IsError)
                    {
                        var specialization = await characterRepository.GetByIdAsync(id.Value);

                        if (specialization is null)
                            context.AddFailure($"Specialization with id {value} does not exist in the database.");
                    }
                    else
                    {
                        context.AddFailure(id.FirstError.Description);
                    }
                    
                });
        }
    }
}
