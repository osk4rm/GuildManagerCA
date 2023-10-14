using ErrorOr;
using GuildManagerCA.Application.Common.Authentication;
using GuildManagerCA.Application.Common.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildManagerCA.Domain.Common.Errors;
using GuildManagerCA.Application.Authentication.Common;
using GuildManagerCA.Domain.UserAggregate;
using GuildManagerCA.Domain.UserRoleAggregate.ValueObjects;
using GuildManagerCA.Domain.Common.Constants;

namespace GuildManagerCA.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            IPasswordHasher passwordHasher)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var defaultRole = await _userRoleRepository.GetRoleByName(Constants.UserRole.DefaultRole);

            if (defaultRole is null)
            {
                return Errors.UserRole.DefaultRoleNotSet;
            }

            var user = User.Create(
                command.FirstName,
                command.LastName,
                command.NickName,
                command.Email,
                _passwordHasher.HashPassword(command.Password),
                DateTime.Now,
                DateTime.Now,
                UserRoleId.Create(defaultRole.Id.Value));

            await _userRepository.AddAsync(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
