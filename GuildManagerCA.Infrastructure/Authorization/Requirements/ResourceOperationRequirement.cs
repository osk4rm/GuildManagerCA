using GuildManagerCA.Domain.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Authorization.Requirements
{
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperationType ResourceOperationType { get; set; }

        public ResourceOperationRequirement(ResourceOperationType resourceOperationType)
        {
            ResourceOperationType = resourceOperationType;
        }

    }
}
