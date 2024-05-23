using System.ComponentModel.DataAnnotations;


namespace fitness_tracker_serverside.Dtos
{
    public class Login
    {

        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
