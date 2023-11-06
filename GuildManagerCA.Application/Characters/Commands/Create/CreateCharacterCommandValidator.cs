using FluentValidation;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Characters.Commands.Create
{
    public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
    {
        public CreateCharacterCommandValidator(
            ICharacterRepository characterRepository,
            ISpecializationRepository specializationRepository)
        {
            RuleFor(c => c.Name)
                .CustomAsync(async (value, context, token) =>
                {
                    var nameExists = await characterRepository.CharacterWithNameExists(value);
                    if(nameExists)
                    {
                        context.AddFailure("Name", "Character with this name already exists.");
                    }
                })
                .NotEmpty();

            RuleFor(x => x.ItemLevel)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.SpecializationIds)
                .CustomAsync(async (value, context, token) =>
                {
                    var specIds = value.Select(s => SpecializationId.Create(s));
                    bool allSpecsPresentInDb = await specializationRepository.VerifySpecializationIds(specIds);

                    if (!allSpecsPresentInDb)
                    {
                        context.AddFailure("One or more of given class specialization IDs are invalid.");
                    }

                    bool allSpecsAreFromTheSameClass = await specializationRepository.VerifySpecializationsHaveSameClassName(specIds);

                    if(!allSpecsAreFromTheSameClass)
                    {
                        context.AddFailure("Specializations must be from the same class");
                    }
                });
        }
    }
}
