using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{
    public class Appointment
    {
        public Appointment()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid UserFK { get; set; }
        public User User { get; set; }
    }
}
