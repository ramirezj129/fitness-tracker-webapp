namespace fitness_tracker_serverside.Entities;

public class Workout
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan? Duration { get; set; }
    public string Type { get; set; }
    public string Notes { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<Exercise> Exercises { get; set; }
}
