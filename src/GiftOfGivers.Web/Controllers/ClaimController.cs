using Microsoft.AspNetCore.Mvc;
using GiftOfGivers.Services;
using GiftOfGivers.Models;

namespace GiftOfGivers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClaimController : ControllerBase
{
    private readonly IClaimService _service;
    public ClaimController(IClaimService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClaimRequest req)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _service.CreateClaimAsync(req, "user-1");
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var claim = await _service.GetClaimAsync(id);
        if (claim is null) return NotFound();
        return Ok(claim);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _service.GetClaimsForUserAsync("user-1");
        return Ok(list);
    }
}
