using Microsoft.AspNetCore.Mvc;
using GiftOfGiversApp.Services;
using GiftOfGiversApp.Models;

namespace GiftOfGiversApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClaimController : ControllerBase
{
    private readonly IClaimService _svc;
    public ClaimController(IClaimService svc) => _svc = svc;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClaimRequest req)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var dto = await _svc.CreateClaimAsync(req, "user-1");
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var dto = await _svc.GetClaimAsync(id);
        if (dto is null) return NotFound();
        return Ok(dto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _svc.GetClaimsForUserAsync("user-1"));
}
