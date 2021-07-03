using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class Days
    {
        public int Id { get; set; }
        public string Namd { get; set; }
        public bool IsCheched { get; set; }
        //public List<SelectListItem> OrgList { get; set; }
    }
}
