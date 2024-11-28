using Microsoft.AspNetCore.Mvc;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Service;

namespace MusicFestivalManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FestivalsController : ControllerBase
{
    private readonly FestivalService _service;

    public FestivalsController(FestivalService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFestival([FromBody] Festival festival)
    {
        var createdFestival = await _service.CreateFestivalAsync(festival);
        return CreatedAtAction(nameof(GetFestivalById), new { id = createdFestival.FestivalId }, createdFestival);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFestivals()
    {
        var festivals = await _service.GetAllFestivalsAsync();
        return Ok(festivals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFestivalById(int id)
    {
        var festival = await _service.GetFestivalByIdAsync(id);
        if (festival == null)
            return NotFound();
        return Ok(festival);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFestival(int id, [FromBody] Festival festival)
    {
        if (id != festival.FestivalId)
            return BadRequest("ID mismatch");

        await _service.UpdateFestivalAsync(festival);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFestival(int id)
    {
        await _service.DeleteFestivalAsync(id);
        return NoContent();
    }
}
