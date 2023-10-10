using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace GuildManagerCA.Tests.Integration.Setup.Auth
{
    public class FakeUserFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Unauthorized-Test"))
            {
                var claimsPrincipal = new ClaimsPrincipal();
                claimsPrincipal.AddIdentity(new ClaimsIdentity(
                    new[]
                    {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Role, "Admin")
                    }));

                context.HttpContext.User = claimsPrincipal;
            }

            await next();
        }

    }
}
