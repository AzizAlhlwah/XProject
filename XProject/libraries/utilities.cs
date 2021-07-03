using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.libraries
{
    public class utilities
    {

        //private readonly DBContext _context;
        //private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public utilities(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        

        //IHttpContextAccessor httpContextAccessor;
        //public utilities(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}


        //public bool IsLogin()
        //{
        //    var Nid = httpContextAccessor.HttpContext.Session.GetString("UserId");
        //    if (Nid != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


    }
}
