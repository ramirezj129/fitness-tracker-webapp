using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using fitness_tracker_serverside.DbContext;
using fitness_tracker_serverside.Dtos;
using fitness_tracker_serverside.Entities;
using Microsoft.EntityFrameworkCore;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class MeasurementController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MeasurementController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // POST: api/Measurement
    [HttpPost]
    public async Task<IActionResult> CreateMeasurement([FromBody] MeasurementDto measurementDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim.Value);

        var measurement = _mapper.Map<Measurement>(measurementDto);
        measurement.UserId = userId;

        _context.Measurements.Add(measurement);
        await _context.SaveChangesAsync();

        var createdMeasurementDto = _mapper.Map<MeasurementDto>(measurement);

        return CreatedAtAction(nameof(GetMeasurement), new { id = measurement.Id }, createdMeasurementDto);
    }

    // GET: api/Measurement
    [HttpGet]
    public async Task<IActionResult> GetMeasurements()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim.Value);

        var measurements = await _context.Measurements
            .Where(m => m.UserId == userId)
            .ToListAsync();

        var measurementDtos = _mapper.Map<IEnumerable<MeasurementDto>>(measurements);

        return Ok(measurementDtos);
    }

    // GET: api/Measurement/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMeasurement(int id)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim.Value);

        var measurement = await _context.Measurements
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

        if (measurement == null)
        {
            return NotFound();
        }

        var measurementDto = _mapper.Map<MeasurementDto>(measurement);

        return Ok(measurementDto);
    }

    // PUT: api/Measurement/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMeasurement(int id, [FromBody] MeasurementDto measurementDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim.Value);

        if (id != measurementDto.Id)
        {
            return BadRequest();
        }

        var measurement = await _context.Measurements
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

        if (measurement == null)
        {
            return NotFound();
        }

        _mapper.Map(measurementDto, measurement);

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

    // DELETE: api/Measurement/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMeasurement(int id)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim.Value);

        var measurement = await _context.Measurements
            .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

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
