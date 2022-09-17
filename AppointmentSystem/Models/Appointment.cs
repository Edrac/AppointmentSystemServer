using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.Models
{
    public class Appointment
    {
        [Required]
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
