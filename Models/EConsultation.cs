using System.ComponentModel.DataAnnotations;

namespace DoktormandenDk.Models
{
    public class EConsultation
    {
        [Key]
        public int EConsultationId { get; set; }
        [Required]
        [Display(Name ="Emne")]
        public string Subject { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int GPId { get; set; }   

        public virtual Patient? Patient { get; set; }
        public virtual GP? GP { get; set; }
        public virtual ICollection<ECMessage>? Messages { get; set; }
    }
}
