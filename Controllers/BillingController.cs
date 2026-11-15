using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers;

[ApiController]
[Route("billing")]
public class BillingController : ControllerBase
{
    private readonly string PaymentApiKey =
        Environment.GetEnvironmentVariable("PAYMENT_API_KEY") ?? "";

    [HttpGet("status")]
    public IActionResult Status()
    {
        return Ok(new { configured = PaymentApiKey.Length > 0 });
    }
}
