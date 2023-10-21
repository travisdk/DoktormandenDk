using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoktormandenDk.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public int PatientId { get; set; } // Patient
        [Required]
        public int GPId { get; set; }     // General practitioner 
        [Required]
        [Display(Name="Mødetidspunkt")]
        public DateTime AppointmentTime { get; set; }
        [Required]
        [Display(Name="Emne")]
        public string Subject { get; set; } // What is the appointment about?

        public virtual Patient Patient { get; set; }
        public virtual GP GP { get; set; }

    }
}
