namespace fitness_tracker_serverside.Dtos
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public TimeSpan Duration { get; set; }
        public int UserId { get; set; }
    }
}
