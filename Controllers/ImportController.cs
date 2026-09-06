using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Invoicing.Controllers;

[ApiController]
[Route("import")]
public class ImportController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] string body)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
        var obj = JsonConvert.DeserializeObject<object>(body, settings);
        return Ok(obj?.ToString());
    }
}
