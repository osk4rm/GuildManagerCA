using FluentValidation;
using GuildManagerCA.Application.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.FirstName).NotEmpty();

            RuleFor(x=>x.LastName).NotEmpty();

            RuleFor(x=>x.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var user = userRepository.GetUserByEmail(value);
                    if (user is not null)
                    {
                        context.AddFailure("Email", "User with this email already exists.");
                    }
                });

            RuleFor(x=>x.Password).NotEmpty()
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
        }
    }
}
