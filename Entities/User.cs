using Microsoft.AspNetCore.Identity;


namespace fitness_tracker_serverside.Entities
{
    public class User : IdentityUser<int>
    {


        public ICollection<Measurement> Measurements { get; set; }

        public ICollection<Workout> Workouts { get; set; }


    }
}
