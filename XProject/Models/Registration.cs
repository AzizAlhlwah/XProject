using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class Registration
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public List<SelectListItem> OrgList { get; set; }
    }
}
