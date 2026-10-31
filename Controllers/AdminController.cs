using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers;

[ApiController]
[Route("admin")]
[Authorize]
public class AdminController : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost("delete-user")]
    public IActionResult DeleteUser([FromQuery] int id)
    {
        // Removes any user by id. Should be admins only.
        return Ok($"deleted {id}");
    }
}
