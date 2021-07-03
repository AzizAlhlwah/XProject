using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class Coach
    {
        
        public int ID { get; set; }
        [Key]
        //[StringLength(10)]
        public int nationalId { get; set; }
        //[Required (ErrorMessage = "الرجاء ادخال الاسم")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "الرجاء ادخال رقم الجوال")]
        //[StringLength(10)]
        public string Mobile { get; set; }
        //[Required(ErrorMessage = "الرجاء ادخال البريد الإلكتروني")]
        public string Email { get; set; }
        public string DesiredTime { get; set; }
        public string DesiredPeriod { get; set; }
        public int HourPrice { get; set; }
    }
}
