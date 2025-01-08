using Microsoft.AspNetCore.Mvc;
using MusicFestivalManagement.Dtos;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Repository.Interfaces;

namespace MusicFestivalManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PerformancesController : ControllerBase
{
    private readonly IPerformanceRepository _repository;

    public PerformancesController(IPerformanceRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerformance([FromBody] CreatePerformanceDto performance)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _repository.AddPerformanceAsync(performance);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPerformances()
    {
        var performances = await _repository.GetAllPerformancesAsync();
        return Ok(performances);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerformanceById(int id)
    {
        var performance = await _repository.GetPerformanceByIdAsync(id);
        if (performance == null)
            return NotFound();

        return Ok(performance);
    }

/*    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerformance(int id, [FromBody] UpdatePerformanceDto performanceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != performanceDto.Id)
            return BadRequest("ID mismatch");

        var performance = await _repository.GetPerformanceByIdAsync(id);
        if (performance == null)
            return NotFound();

        performance.Name = performanceDto.Name;
        performance.Date = performanceDto.Date;
        performance.FestivalId = performanceDto.FestivalId;

        await _repository.UpdatePerformanceAsync(performance);
        return NoContent();
    }*/

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerformance(int id)
    {
        var performance = await _repository.GetPerformanceByIdAsync(id);
        if (performance == null)
            return NotFound();

        await _repository.DeletePerformanceAsync(id);
        return NoContent();
    }

    [HttpGet("festival/{festivalId}")]
    public async Task<IActionResult> GetPerformancesByFestivalId(int festivalId)
    {
        var performances = await _repository.GetPerformancesByFestivalIdAsync(festivalId);
        return Ok(performances);
    }
}
