using ErrorOr;
using GuildManagerCA.Application.Authentication.Common;
using GuildManagerCA.Application.Common.Authentication;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.Common.Errors;
using GuildManagerCA.Domain.UserAggregate;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Authentication.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ErrorOr<ChangePasswordResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<ErrorOr<ChangePasswordResult>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var userId = UserId.Create(request.UserId);
            if (userId.IsError)
            {
                return Errors.User.InvalidUserId;
            }

            var user = await _userRepository.GetByIdAsync(userId.Value);

            try
            {
                string passwordHash = _passwordHasher.HashPassword(request.NewPassword);
                user!.ChangePassword(passwordHash);

                await _userRepository.UpdateAsync(user);

                return new ChangePasswordResult(user.Email, user.Password);
            }

            catch (Exception)
            {
                return Errors.Common.RepositoryUpdate;
            }
            
        }
    }
}
