using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fitness_tracker_serverside.Entities;
using fitness_tracker_serverside.DbContext;
using System.Linq;
using System.Threading.Tasks;

namespace fitness_tracker_serverside.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] Workout workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ensure the User reference is set
            var user = await _context.Users.FindAsync(workout.UserId);
            if (user == null)
            {
                return BadRequest("Invalid UserId");
            }
            workout.User = user;

            // Ensure each Exercise has the Workout reference set
            if (workout.Exercises != null && workout.Exercises.Any())
            {
                foreach (var exercise in workout.Exercises)
                {
                    exercise.Workout = workout;
                }
            }

            _context.Workouts.Add(workout);

            try
            {
                await _context.SaveChangesAsync();
                return Ok(workout);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkout(int id)
        {
            var workout = await _context.Workouts
                                       .Include(w => w.Exercises)
                                       .FirstOrDefaultAsync(w => w.Id == id);
            if (workout == null)
            {
                return NotFound();
            }
            return Ok(workout);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkout(int id, [FromBody] Workout workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            _context.Entry(workout).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Workouts.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
