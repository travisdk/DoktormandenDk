using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DoktormandenDk.Models
{

    public class GP : IUser {

        [Key]
        public int GPId { get; set; }
        [Required]
        [Display(Name="Brugernavn")]
        public string UserName { get; set; } // Link to our demousers setup
        [Required]
        [Display(Name = "Navn")]
        public string Name { get; set; }
        [Required]
        [MaxLength(12)]
        [Display(Name = "Licenskode")]
        public string License { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
