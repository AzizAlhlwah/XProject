using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XProject.Models;

namespace XProject.Controllers
{
    public class TraineeController : Controller
    {
        private readonly DBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TraineeController(ILogger<CoachController> logger, DBContext context,
            IWebHostEnvironment hostingEnvironment
            , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            return View();
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

        public IActionResult MyRequests()
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            string NID = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            int ConVertNID = Convert.ToInt32(NID);
            //var User = _context.applactionUsers.Where(x => x.rolls == "2").FirstOrDefault();

            var Request = _context.trainingoffers.Where(x => x.nationalId.Equals(ConVertNID)).FirstOrDefault();

            ViewBag.TriningOffer = _context.trainingoffers.Where(x => x.nationalId.Equals(ConVertNID)).ToList();

            return View(Request);
        }


        public IActionResult NewRequests()
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            return View();
        
        }

        [HttpPost]
        public IActionResult NewRequests(TrainingOffers TO)
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            _context.Add(TO);

           var Result = _context.SaveChanges();

            return View();

        }

        public IActionResult Settings()
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            return View();
        }


       
    }
}
