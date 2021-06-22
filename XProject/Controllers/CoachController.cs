using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XProject.Models;

namespace XProject.Controllers
{
    public class CoachController : Controller
    {
        private readonly DBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CoachController(ILogger<CoachController> logger, DBContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;

            _webHostEnvironment = hostingEnvironment;

        }


        public IActionResult Index()
        {

            var result = _context.coach.Where(x => x.Name != null);

            return View(result);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Coach model)
        {
            if (ModelState.IsValid)
            {
                Coach c = new Coach();
                c.Name = model.Name;
                c.nationalId = model.nationalId;
                c.Mobile = model.Mobile;
                c.DesiredPeriod = model.DesiredPeriod;
                c.DesiredTime = model.DesiredTime;
                c.Email = model.Email;

                _context.coach.Add(c);
                 var result = _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View();
        }


    }
}