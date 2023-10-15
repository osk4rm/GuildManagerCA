using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Common.Authentication
{
    public interface IUserContextService
    {
        Guid? Id { get; }
        ClaimsPrincipal? User { get; }
    }
}
