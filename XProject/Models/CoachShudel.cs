using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class CoachShudel
    {
        [Key]
        public int Id { get; set; }

        public string Hours { get; set; }

       

    }
}
