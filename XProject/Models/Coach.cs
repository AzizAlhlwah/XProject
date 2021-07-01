using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class Coach
    {
        
        public int ID { get; set; }
        [Key]
        public int nationalId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string DesiredTime { get; set; }
        public string DesiredPeriod { get; set; }
        public int HourPrice { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class Coach
    {
        
        public int ID { get; set; }
        [Key]
        public int nationalId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string DesiredTime { get; set; }
        public string DesiredPeriod { get; set; }
        public int HourPrice { get; set; }
    }
}
