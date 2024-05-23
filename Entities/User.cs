using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;


namespace fitness_tracker_serverside.Entities
{
    public class User : IdentityUser<int>
    {

        public ICollection<Measurement> Measurements { get; set; }
        public ICollection<Exercise> Exercises { get; set; }



    }
}
