using FluentValidation;
using GuildManagerCA.Application.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Commands.Create
{
    public class CreateSpecializationValidator : AbstractValidator<CreateSpecializationCommand>
    {
        public CreateSpecializationValidator(ISpecializationRepository specializationRepository)
        {
            RuleFor(x => x.SpecializationRole)
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50)
                .CustomAsync(async (value, context, token) =>
                {
                    var specializations = await specializationRepository.GetAsync(
                        predicate: s => s.Name == value
                        );

                    if (specializations.Count != 0)
                    {
                        context.AddFailure($"Specialization with name {value} already exists");
                    }
                });

            RuleFor(x => x.ClassName)
                .NotEmpty()
                .MaximumLength(50);

        }
    }
}
