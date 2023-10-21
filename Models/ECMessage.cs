using System.ComponentModel.DataAnnotations;

namespace DoktormandenDk.Models
{
    public enum Sender
    {
        GP, PATIENT
    }
    public class ECMessage
    {

        [Key]
        public int EcMessageId { get; set; }
        [Required]  
        public int EConsultationId { get; set; }    
        [Required]
        [Display(Name="Besked")]
        public string Message { get; set; }
        [Required] // GP or PATIENT is the options for sender
        [Display(Name="Afsender")]
        public Sender Sender { get; set; }

        public virtual EConsultation? EConsultation { get; set; }

    }
}
