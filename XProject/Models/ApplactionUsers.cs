using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class ApplactionUsers
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public int nationalId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string Confirmpassword { get; set; }

        public string rolls { get; set; }

        public string Hours { get; set; }
    }
}
