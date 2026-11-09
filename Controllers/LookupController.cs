using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.XPath;

namespace Invoicing.Controllers;

[ApiController]
[Route("lookup")]
public class LookupController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string name)
    {
        var doc = new XmlDocument();
        doc.Load("users.xml");
        var expr = "/users/user[@name='" + name + "']/role";
        var node = doc.SelectSingleNode(expr);
        return Ok(node?.InnerText ?? "none");
    }
}
