using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers;

[ApiController]
[Route("upload")]
public class UploadController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(IFormFile file)
    {
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (ext != ".png" && ext != ".jpg" && ext != ".pdf")
            return BadRequest("unsupported type");
        var name = Guid.NewGuid().ToString() + ext;
        var path = Path.Combine("storage/uploads", name);
        using var fs = System.IO.File.Create(path);
        await file.CopyToAsync(fs);
        return Ok($"/files/{name}");
    }
}
