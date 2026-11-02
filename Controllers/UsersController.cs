using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers;

public class UserModel
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
}

[ApiController]
[Route("users")]
[Authorize]
public class UsersController : ControllerBase
{
    [HttpPost("update")]
    public IActionResult Update([FromBody] UserModel m)
    {
        // Persists the submitted profile.
        return Ok($"{m.Name}:{m.IsAdmin}");
    }
}
