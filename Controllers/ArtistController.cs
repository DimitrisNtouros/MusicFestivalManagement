using Microsoft.AspNetCore.Mvc;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Service;

namespace MusicFestivalManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtistsController : ControllerBase
{
    private readonly ArtistService _service;

    public ArtistsController(ArtistService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateArtist([FromBody] Artist artist)
    {
        var createdArtist = await _service.CreateArtistAsync(artist);
        return CreatedAtAction(nameof(GetArtistById), new { id = createdArtist.ArtistId }, createdArtist);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllArtists()
    {
        var artists = await _service.GetAllArtistsAsync();
        return Ok(artists);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArtistById(int id)
    {
        var artist = await _service.GetArtistByIdAsync(id);
        if (artist == null)
            return NotFound();

        return Ok(artist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArtist(int id, [FromBody] Artist artist)
    {
        if (id != artist.ArtistId)
            return BadRequest("ID mismatch");

        await _service.UpdateArtistAsync(artist);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArtist(int id)
    {
        await _service.DeleteArtistAsync(id);
        return NoContent();
    }
}