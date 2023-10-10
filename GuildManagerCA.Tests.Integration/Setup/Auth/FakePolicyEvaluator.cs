﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using System.Security.Claims;

namespace GuildManagerCA.Tests.Integration.Setup.Auth
{
    public class FakePolicyEvaluator : IPolicyEvaluator
    {
        public Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Unauthorized-Test"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            var claimsPrincipal = new ClaimsPrincipal();
            var ticket = new AuthenticationTicket(claimsPrincipal, "Test");
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }


        public Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy, AuthenticateResult authenticationResult, HttpContext context, object? resource)
        {
            var result = PolicyAuthorizationResult.Success();

            return Task.FromResult(result);
        }
    }
}
