using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class TrainingOffers
    {
        [Key]
        public int Id { get; set; }
        public int nationalId { get; set; }
        public double Price { get; set; }
        public int Hour { get; set; }
        public string Days { get; set; }
        public string Description { get; set; }
        public string period { get; set; }
        public string OwnerCar { get; set; }
        public string PaymantMethod { get; set; }

    }
}
