using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{
    public class User
    {
        public User()
        {
            Id = "0000-aaaa-0000";
            Appointments = new HashSet<Appointment>();
        }

        [Required]
        public string Id { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
