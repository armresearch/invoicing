using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Invoicing.Controllers;

[ApiController]
[Route("xml")]
public class XmlController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] string body)
    {
        var doc = new XmlDocument();
        doc.XmlResolver = new XmlUrlResolver();
        doc.LoadXml(body);
        return Ok(doc.DocumentElement?.Name);
    }
}
