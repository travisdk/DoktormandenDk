using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DoktormandenDk.Models
{


    public class Patient : IUser {

        [Key]
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "Brugernavn")]
        public string UserName { get; set; } // Link to our demousers setup
        [Required]
        [Display(Name = "Navn")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fødselsdato")]
        public DateTime? BirthDay { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<EConsultation>? EConsultations { get; set; }

    }
}
