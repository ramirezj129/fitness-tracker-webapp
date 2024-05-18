using fitness_tracker_serverside.Entities;
using fitness_tracker_serverside.DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class MeasurementController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MeasurementController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurements()
    {
        return await _context.Measurements.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Measurement>> GetMeasurement(int id)
    {
        var measurement = await _context.Measurements.FindAsync(id);

        if (measurement == null)
        {
            return NotFound();
        }

        return measurement;
    }

    [HttpPost]
    public async Task<ActionResult<Measurement>> PostMeasurement(Measurement measurement)
    {
        _context.Measurements.Add(measurement);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMeasurement), new { id = measurement.Id }, measurement);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMeasurement(int id, Measurement measurement)
    {
        if (id != measurement.Id)
        {
            return BadRequest();
        }

        _context.Entry(measurement).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MeasurementExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMeasurement(int id)
    {
        var measurement = await _context.Measurements.FindAsync(id);
        if (measurement == null)
        {
            return NotFound();
        }

        _context.Measurements.Remove(measurement);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MeasurementExists(int id)
    {
        return _context.Measurements.Any(e => e.Id == id);
    }
}
