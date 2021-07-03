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
