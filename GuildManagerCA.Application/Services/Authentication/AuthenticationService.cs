using ErrorOr;
using GuildManagerCA.Application.Common.Authentication;
using GuildManagerCA.Application.Common.Errors;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.Common.Errors;
using GuildManagerCA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            //1. validate the user exists
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            //2. valdiate the password is correct
            if(user.Password != password) 
            {
                return Errors.Authentication.InvalidCredentials;
            }
            //3. create jwt
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            //1. validate the user doesn't exist
            if(_userRepository.GetUserByEmail(email) is not null) 
            {
                return Errors.User.DuplicateEmail;
            }
            //2. create user and generate unique id & persist to db
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            //3. create jwt
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
