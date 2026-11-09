using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers;

[ApiController]
[Route("billing")]
public class BillingController : ControllerBase
{
    // Payment provider credential.
    private const string PaymentApiKey = "a3f1c9d84b7e2056f1c0d9e8b7a6c5d4";

    [HttpGet("status")]
    public IActionResult Status()
    {
        return Ok(new { configured = PaymentApiKey.Length > 0 });
    }
}
