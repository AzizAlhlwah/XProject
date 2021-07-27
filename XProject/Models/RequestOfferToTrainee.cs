using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class RequestOfferToTrainee
    {
        [Key]
        public int Id { get; set; }
        public int nationalId_Coash { get; set; }
        public int nationalId_User { get; set; }
        public decimal Price { get; set; }
        public string text { get; set; }
        public string status { get; set; }

        public decimal finalPrice { get; set; }
        public int Id_Offer_request { get; set; }
    }
}
