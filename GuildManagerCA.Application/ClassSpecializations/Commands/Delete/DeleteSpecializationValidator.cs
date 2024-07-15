using FluentValidation;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Commands.Delete
{
    public class DeleteSpecializationValidator : AbstractValidator<DeleteSpecializationCommand>
    {
        public DeleteSpecializationValidator(ISpecializationRepository specializationRepository)
        {
            RuleFor(x=>x.Id)
                .NotEmpty()
                .CustomAsync(async (value, context, cancellationToken) =>
                {
                    var id = SpecializationId.Create(value);
                    if (!id.IsError)
                    {
                        var specialization = await specializationRepository.GetByIdAsync(id.Value);
                        if(specialization is null)
                        {
                            context.AddFailure($"Specialization with id {value} does not exist in the database.");
                        }
                    }
                });
        }
    }
}
