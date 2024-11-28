using Microsoft.AspNetCore.Mvc;
using MusicFestivalManagement.Models;
using MusicFestivalManagement.Service;

namespace MusicFestivalManagement.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class PerformancesController : ControllerBase
    {
        private readonly PerformanceService _service;

        public PerformancesController(PerformanceService service)
        {
            _service = service;
        }

    [HttpPost]
    public async Task<IActionResult> CreatePerformance([FromBody] Performance performance, [FromQuery] string creatorName)
    {
        if (string.IsNullOrEmpty(creatorName))
            return BadRequest("Creator name is required.");

        var createdPerformance = await _service.CreatePerformanceAsync(performance, creatorName);
        return CreatedAtAction(nameof(GetPerformanceById), new { id = createdPerformance.PerformanceId }, createdPerformance);
    }

    [HttpGet]
        public async Task<IActionResult> GetAllPerformances()
        {
            var performances = await _service.GetAllPerformancesAsync();
            return Ok(performances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerformanceById(int id)
        {
            var performance = await _service.GetPerformanceByIdAsync(id);
            if (performance == null)
                return NotFound();
            return Ok(performance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerformance(int id, [FromBody] Performance performance)
        {
            if (id != performance.PerformanceId)
                return BadRequest("ID mismatch");

            await _service.UpdatePerformanceAsync(performance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformance(int id)
        {
            await _service.DeletePerformanceAsync(id);
            return NoContent();
        }

        [HttpGet("festival/{festivalId}")]
        public async Task<IActionResult> GetPerformancesByFestivalId(int festivalId)
        {
            var performances = await _service.GetPerformancesByFestivalIdAsync(festivalId);
            return Ok(performances);
        }
    }
