using FluentValidation;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Commands.SetActivity
{
    public class SetActivityCommandValidator : AbstractValidator<SetActivityCommand>
    {
        public SetActivityCommandValidator(ISpecializationRepository specializationRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .CustomAsync(async (value, context, token) =>
                {
                    var id = SpecializationId.Create(value);
                    if(!id.IsError)
                    {
                        var spec = await specializationRepository.GetByIdAsync(id.Value);
                        if(spec is null)
                        {
                            context.AddFailure($"Spec with ID {value} does not exist in the database.");
                        }
                    }
                });

            RuleFor(x => new { x.Id, x.IsActive })
                .CustomAsync(async (value, context, token) =>
                {
                    var id = SpecializationId.Create(value.Id);
                    if (!id.IsError)
                    {
                        string activeOrInactiveText = value.IsActive ? "active" : "inactive";
                        var spec = await specializationRepository.GetByIdAsync(id.Value);
                        if(spec is not null && spec.IsActive == value.IsActive)
                        {
                            context.AddFailure($"Specialization with id {value.Id} is already {activeOrInactiveText}.");
                        }
                    }
                });
        }
    }
}
