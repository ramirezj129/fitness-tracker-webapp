namespace fitness_tracker_serverside.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
        public ICollection<MeasurementDto> Measurements { get; set; } = new List<MeasurementDto>();
    }
}
