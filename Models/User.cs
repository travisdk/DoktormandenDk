using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DoktormandenDk.Models
{
    public enum Role
    {
        PHYSICIAN,
        PATIENT
    }

    public class User {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public Role Role { get; set; }
    }
}
