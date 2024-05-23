namespace fitness_tracker_serverside.Entities;
using Newtonsoft.Json;


public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public TimeSpan Duration { get; set; }
        public int UserId { get; set; } // Foreign key
        public User User { get; set; }

}

