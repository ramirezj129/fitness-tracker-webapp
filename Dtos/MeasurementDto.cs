namespace fitness_tracker_serverside.Dtos
{
    public class MeasurementDto
    {
        public int Id { get; set; } // Include Id for updates and deletion
        public string Type { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
