using Microsoft.AspNetCore.Mvc;
using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FestivalController : ControllerBase
{
    private readonly IFestivalRepository _repository;

    public FestivalController(IFestivalRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFestival([FromBody] CreateFestivalDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _repository.AddFestivalAsync(dto);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFestivalById(int id)
    {
        var festival = await _repository.GetFestivalByIdAsync(id);
        if (festival == null)
            return NotFound(new { Error = "Festival not found." });

        return Ok(festival);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFestivals()
    {
        var festivals = await _repository.GetAllFestivalsAsync();
        return Ok(festivals);
    }

    /*[HttpPut("{id}")]
    public async Task<IActionResult> UpdateFestival(int id, [FromBody] UpdateFestivalDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var existingFestival = await _repository.GetFestivalByIdAsync(id);
            if (existingFestival == null)
                return NotFound(new { Error = "Festival not found." });

            await _repository.UpdateFestivalAsync(dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }*/

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFestival(int id)
    {
        try
        {
            var existingFestival = await _repository.GetFestivalByIdAsync(id);
            if (existingFestival == null)
                return NotFound(new { Error = "Festival not found." });

            await _repository.DeleteFestivalAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }
}
