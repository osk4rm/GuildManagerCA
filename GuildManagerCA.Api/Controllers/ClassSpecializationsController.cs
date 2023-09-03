using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerCA.Api.Controllers;

[Route("[controller]")]
public class ClassSpecializationsController : ApiController
{
    [HttpGet]
    public IActionResult GetClassSpecializations()
    {
        return Ok(Array.Empty<string>());
    }
}
