using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoktormandenDk.Models
{

    public enum Category
    {
        Samtale,  Opfølgning, Blodprøve, Vaccination
    }
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
        [Display(Name = "Kategori")]
        public Category Category { get; set; } // Category for the reason for the appointment, see above
   
        [Display(Name="Besked")]
        public string? AppointmentMessage { get; set; }  // Details about the appointment

        public virtual Patient Patient { get; set; }
        public virtual GP GP { get; set; }

    }
}
