using GuildManagerCA.Application.Common.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Authentication
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid? Id => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        public ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
    }
}
