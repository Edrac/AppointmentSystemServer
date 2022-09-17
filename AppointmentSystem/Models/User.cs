using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        [MinLength(2)]
        public string Id { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
