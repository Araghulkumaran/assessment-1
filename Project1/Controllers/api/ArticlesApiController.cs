using Microsoft.AspNetCore.Mvc;
using Project1.Data;
using Project1.Filters;
using Project1.Models;

[Route("api/[controller]")]
[ApiController]
[BasicAuth]
public class ArticlesApiController : ControllerBase
{
    private readonly DapperHelper _db;
    public ArticlesApiController(DapperHelper db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetArticles()
    {
        var data = _db.Query<ArticleViewModel>("sp_GetArticleList");
        return Ok(data);
    }

    [HttpGet("vendors")]
    public IActionResult Vendors()
    {
        var vendors = _db.Query<VendorModel>("sp_GetVendors");
        return Ok(vendors);
    }

    public class AssignDto { public int VendorId { get; set; } public string ArticleIds { get; set; } = string.Empty; }

    [HttpPost("assign")]
    public IActionResult AssignVendor([FromBody] AssignDto dto)
    {
        _db.Execute("sp_AssignVendorBulk", new { VendorID = dto.VendorId, ArticleIDs = dto.ArticleIds });
        return Ok();
    }

    public class UpdateDto { public string AutoArtID { get; set; } = string.Empty; public int VendorId { get; set; } }

    [HttpPost("update")]
    public IActionResult UpdateVendor([FromBody] UpdateDto dto)
    {
        _db.Execute("sp_AssignVendorBulk", new { VendorID = dto.VendorId, ArticleIDs = dto.AutoArtID });
        return Ok();
    }
}
