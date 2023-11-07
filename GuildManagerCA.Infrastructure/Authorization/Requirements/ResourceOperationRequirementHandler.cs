using GuildManagerCA.Application.Common.Authentication;
using GuildManagerCA.Domain.Authorization.Requirements;
using GuildManagerCA.Domain.CharacterAggregate;
using GuildManagerCA.Domain.RaidEventAggregate;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Authorization.Requirements
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Character>
    {
        private readonly IUserContextService _userContextService;

        public ResourceOperationRequirementHandler(IUserContextService userContextService)
        {
            _userContextService = userContextService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Character resource)
        {
            if (requirement.ResourceOperationType == ResourceOperationType.Create || requirement.ResourceOperationType == ResourceOperationType.Read)
            {
                context.Succeed(requirement);
            }

            //TODO: does this need a check?
            var userId = UserId.Create(_userContextService.Id!.Value);

            if (resource.UserId == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
