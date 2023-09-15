using BC = BCrypt.Net.BCrypt;
using GuildManagerCA.Application.Common.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace GuildManagerCA.Infrastructure.Authentication.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly int _workfactor;

        public PasswordHasher(IOptions<BCryptSettings> bcryptOptions)
        {
            _workfactor = bcryptOptions.Value.WorkFactor;
        }

        public string HashPassword(string password)
        {
            return BC.EnhancedHashPassword(password, _workfactor);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BC.EnhancedVerify(password, hashedPassword);
        }


    }
}
