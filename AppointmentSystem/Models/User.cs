using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{
    public class User
    {
        public User()
        {
            Id = "";
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
