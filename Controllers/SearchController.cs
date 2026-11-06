using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Invoicing.Controllers;

[ApiController]
[Route("search")]
public class SearchController : ControllerBase
{
    private const string Conn = "Server=db;Database=app;User Id=app;Password=secret;";

    [HttpGet("health")]
    public IActionResult Health() => Ok("ok");

    [HttpGet]
    public IActionResult Get([FromQuery] string q)
    {
        using var c = new SqlConnection(Conn);
        c.Open();
        var sql = "SELECT Id, Name FROM Items WHERE Name LIKE @q";
        using var cmd = new SqlCommand(sql, c);
        cmd.Parameters.AddWithValue("@q", "%" + q + "%");
        using var r = cmd.ExecuteReader();
        var names = new List<string>();
        while (r.Read()) names.Add(r.GetString(1));
        if (names.Count == 0) return NotFound();
        return Ok(names);
    }
}
