using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers;

[ApiController]
[Route("upload")]
public class UploadController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(IFormFile file)
    {
        var path = Path.Combine("wwwroot/uploads", file.FileName);
        using var fs = System.IO.File.Create(path);
        await file.CopyToAsync(fs);
        return Ok($"/uploads/{file.FileName}");
    }
}
