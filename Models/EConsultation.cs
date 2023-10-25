using System.ComponentModel.DataAnnotations;

namespace DoktormandenDk.Models
{
    public class EConsultation
    {
        [Key]
        public int EConsultationId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int GPId { get; set; }
        [Required(ErrorMessage = "Spørgsmål/besked skal angives!")]
        [Display(Name ="Spørgsmål")]
        public string Question { get; set; }

        [Required]
        [Display(Name ="Dato for besked")]
        public DateTime? QuestionTime { get; set; }

        [Display(Name = "Svar")]
        public string? Answer { get; set; }
        [Display(Name = "Dato svar")]
        public DateTime? AnswerTime { get; set; }
        [UIHint("AfsluttetJaNej")] // JA/NEJ instead of checkbox symbol
        [Display(Name = "Afsluttet?")]
        public bool Closed { get; set; } = false;

        public virtual Patient? Patient { get; set; }
        public virtual GP? GP { get; set; }
  
    }
}
