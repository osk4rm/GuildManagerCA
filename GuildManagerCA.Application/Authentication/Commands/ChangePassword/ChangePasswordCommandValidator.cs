using FluentValidation;
using GuildManagerCA.Application.Common.Authentication;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.UserAggregate;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Authentication.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator(IPasswordHasher passwordHasher, IUserRepository userRepository)
        {

            RuleFor(x => x.UserId)
                .NotEmpty()
                .CustomAsync(async (value, context, token) =>
                {
                    var userId = UserId.Create(value);
                    if (!userId.IsError)
                    {
                        if ((await userRepository.GetByIdAsync(userId.Value)) is null)
                        {
                            context.AddFailure($"User with id {value} does not exist in database.");
                        }
                    }
                });

            RuleFor(x => new { x.OldPassword, x.UserId })
                .CustomAsync(async (value, context, token) =>
                {
                    var userId = UserId.Create(value.UserId);
                    if (!userId.IsError)
                    {
                        if ((await userRepository.GetByIdAsync(userId.Value)) is User user)
                            if (passwordHasher.VerifyPassword(value.OldPassword, user.Password) == false)
                            {
                                context.AddFailure("Incorrect password.");
                            }
                    }
                });

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Your password length must be at least 8.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword)
                .WithMessage("Your confirm password doesn't match your password.");
        }
    }
}
