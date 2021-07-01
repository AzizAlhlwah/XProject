using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XProject.Models;
using Microsoft.AspNetCore.Http;
using XProject.libraries;

namespace XProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //utilities uti = new utilities();

        public HomeController(ILogger<HomeController> logger, DBContext context,
                IWebHostEnvironment hostingEnvironment
                ,IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _logger = logger;
                _httpContextAccessor = httpContextAccessor;

            
        }

        public IActionResult Index()
        {
            // Git
            ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            //Set
            //_httpContextAccessor.HttpContext.Session.SetString("UserId", data.emp_id.ToString());
            return View();
        }

        public IActionResult Privacy()
        {
            // Git
            ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


       
        public IActionResult register()
        {
            

            if (IsLogin())
            {
                // You Aready login
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult register(ApplactionUsers user)
        {

            if(user.Password != user.Confirmpassword)
            {
                ViewBag.Error = " كلمة المرور وتاكيد كلمة المرور لاتتطابق   ";

            }
            else { 

                _context.applactionUsers.Add(user);
                int result = _context.SaveChanges();

                if (result == 1)
                {
                    ViewBag.result = "<strong>تم تسجيلك بنجاح!</strong>";
                }
            }
            return View("register");
        }

        public IActionResult login()
        {
            if (IsLogin())
            {
                // You Aready login
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult login(ApplactionUsers user)
        {
           var Result = _context.applactionUsers.Where(x => x.Email == user.Email &&
                                           x.Password == user.Password).FirstOrDefault();
            if (Result != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("UserId",user.nationalId.ToString());
                var roll = Result.rolls;
               _httpContextAccessor.HttpContext.Session.SetString("Roll", roll);

                if(roll == "1")
                {
                    return RedirectToAction("dashboard", "Coach");

                } else if (roll == "2"){
                    return RedirectToAction("dashboard", "Trainee");
                }
                else if(roll == "3")
                {
                    return RedirectToAction("dashboard", "Admin");
                }

                return RedirectToAction("Index","Home");
            }

            ViewBag.result = " <h6> البريد الإلكتروني أو كلمة المرور خاطئة </h6>";

            return View();
        }
        public IActionResult logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

        public IActionResult RedirectBaesOnRoll()
        {
         
            ViewBag.roll = _httpContextAccessor.HttpContext.Session.GetString("Roll");
            if (ViewBag.roll == "1")
            {
                return RedirectToAction("dashboard", "Coach");
            }
            else if  (ViewBag.roll == "2")
            {
                return RedirectToAction("dashboard", "Trainee");
            }
            else
            {
                return RedirectToAction("dashboard", "Admin");
            }

            return RedirectToAction("Index", "Home");

        }
        

        public bool IsLogin()
        {
            var Nid = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            if (Nid != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XProject.Models;
using Microsoft.AspNetCore.Http;
using XProject.libraries;

namespace XProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //utilities uti = new utilities();

        public HomeController(ILogger<HomeController> logger, DBContext context,
                IWebHostEnvironment hostingEnvironment
                ,IHttpContextAccessor httpContextAccessor)
            {
                _context = context;
                _logger = logger;
                _httpContextAccessor = httpContextAccessor;

            
        }

        public IActionResult Index()
        {
            // Git
            ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            //Set
            //_httpContextAccessor.HttpContext.Session.SetString("UserId", data.emp_id.ToString());
            return View();
        }

        public IActionResult Privacy()
        {
            // Git
            ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


       
        public IActionResult register()
        {
            

            if (IsLogin())
            {
                // You Aready login
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult register(ApplactionUsers user)
        {

            if(user.Password != user.Confirmpassword)
            {
                ViewBag.Error = " كلمة المرور وتاكيد كلمة المرور لاتتطابق   ";

            }
            else { 

                _context.applactionUsers.Add(user);
                int result = _context.SaveChanges();

                if (result == 1)
                {
                    ViewBag.result = "<strong>تم تسجيلك بنجاح!</strong>";
                }
            }
            return View("register");
        }

        public IActionResult login()
        {
            if (IsLogin())
            {
                // You Aready login
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult login(ApplactionUsers user)
        {
           var Result = _context.applactionUsers.Where(x => x.Email == user.Email &&
                                           x.Password == user.Password).FirstOrDefault();
            if (Result != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("UserId",user.nationalId.ToString());
                var roll = Result.rolls;
               _httpContextAccessor.HttpContext.Session.SetString("Roll", roll);

                if(roll == "1")
                {
                    return RedirectToAction("dashboard", "Coach");

                } else if (roll == "2"){
                    return RedirectToAction("dashboard", "Trainee");
                }
                else if(roll == "3")
                {
                    return RedirectToAction("dashboard", "Admin");
                }

                return RedirectToAction("Index","Home");
            }

            ViewBag.result = " <h6> البريد الإلكتروني أو كلمة المرور خاطئة </h6>";

            return View();
        }
        public IActionResult logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

        public IActionResult RedirectBaesOnRoll()
        {
         
            ViewBag.roll = _httpContextAccessor.HttpContext.Session.GetString("Roll");
            if (ViewBag.roll == "1")
            {
                return RedirectToAction("dashboard", "Coach");
            }
            else if  (ViewBag.roll == "2")
            {
                return RedirectToAction("dashboard", "Trainee");
            }
            else
            {
                return RedirectToAction("dashboard", "Admin");
            }

            return RedirectToAction("Index", "Home");

        }
        

        public bool IsLogin()
        {
            var Nid = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            if (Nid != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

