using fitness_tracker_serverside.Entities;

public class Measurement
{
    public int Id { get; set; }
    public string Type { get; set; }
    public double Value { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; } // Change type to string
    public User User { get; set; }
}
