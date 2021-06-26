using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XProject.Models;

namespace XProject.Controllers
{
    public class CoachController : Controller
    {
        private readonly DBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CoachController(ILogger<CoachController> logger, DBContext context,
            IWebHostEnvironment hostingEnvironment
            , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Index()
        {
            if(ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            var result = _context.applactionUsers.Where(x => x.nationalId != null);

            return View(result);
        }


        public IActionResult dashboard()
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            return View();
        }

        public IActionResult MyProfile()
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }
            return View();
        }


        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Coach model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Coach c = new Coach();
        //        c.Name = model.Name;
        //        c.nationalId = model.nationalId;
        //        c.Mobile = model.Mobile;
        //        c.DesiredPeriod = model.DesiredPeriod;
        //        c.DesiredTime = model.DesiredTime;
        //        c.Email = model.Email;

        //        _context.coach.Add(c);
        //         var result = _context.SaveChanges();

        //        return RedirectToAction("Index");

        //    }

        //    return View();
        //}

        

    }
}