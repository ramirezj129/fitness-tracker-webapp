using fitness_tracker_serverside.Entities;
using fitness_tracker_serverside.DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ExerciseController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
    {
        return await _context.Exercises.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetExercise(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);

        if (exercise == null)
        {
            return NotFound();
        }

        return exercise;
    }

    [HttpPost]
    public async Task<ActionResult<Exercise>> PostExercise(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetExercise), new { id = exercise.Id }, exercise);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutExercise(int id, Exercise exercise)
    {
        if (id != exercise.Id)
        {
            return BadRequest();
        }

        _context.Entry(exercise).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ExerciseExists(id))
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
    public async Task<IActionResult> DeleteExercise(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }

        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ExerciseExists(int id)
    {
        return _context.Exercises.Any(e => e.Id == id);
    }
}
