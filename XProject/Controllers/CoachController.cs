using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using XProject.libraries;
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
            //if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            //{
            //    return RedirectToAction("login", "Home");
            //}
            //if (_httpContextAccessor.HttpContext.Session.GetString("Roll") != "1")
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            

            var result = _context.applactionUsers.Where(x => x.rolls == "1");

            return View(result);
        }


        public IActionResult dashboard()
        {
            
            if (!Redireact())
            {
               return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult requestOffer()
        {

            var NID = Convert.ToInt32(_httpContextAccessor.HttpContext
                            .Session.GetString("UserId"));

            var model = _context.requestOfferToTrainee.Where(x => x.nationalId_Coash == NID).ToList();
            int Id_offer  = model.Select(x => x.Id_Offer_request).FirstOrDefault();
            

            ViewBag.NameOffier = _context.trainingoffers.Where(x => x.Id == Id_offer).FirstOrDefault().Description;
            ViewBag.hours = _context.trainingoffers.Where(x => x.Id == Id_offer).FirstOrDefault().Hour;

            return View(model);
        }



        public IActionResult MyProfile()
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }
            if (_httpContextAccessor.HttpContext.Session.GetString("Roll") != "1")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.days = DayLIst();

            var NID = Convert.ToInt32(_httpContextAccessor.HttpContext
                            .Session.GetString("UserId"));

            var result = _context.applactionUsers.Where
                            (x => x.nationalId == NID).ToList();
            ViewBag.InfoCoach = result;
            return View();
        }

        
        [HttpPost]
        public IActionResult MyProfile(string[] AllDaySelected)
        {
            return RedirectToAction("MyProfile");
        }

            public IActionResult Settings()
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }
            if (_httpContextAccessor.HttpContext.Session.GetString("Roll") != "1")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public IActionResult ApplyForOffer(int Id)
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }
            if (_httpContextAccessor.HttpContext.Session.GetString("Roll") != "1")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.NIDUser = _context.trainingoffers.Where(x => x.Id == Id).FirstOrDefault().nationalId;

            ViewBag.NIDCoach = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserId"));

            ViewBag.NameOffier = _context.trainingoffers.Where(x => x.Id == Id).FirstOrDefault().Description;

            ViewBag.Id_Offer_request = Id;

            return View();
        }

        [HttpPost]
        public IActionResult ApplyForOffer(RequestOfferToTrainee offer)
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }
            if (_httpContextAccessor.HttpContext.Session.GetString("Roll") != "1")
            {
                return RedirectToAction("Index", "Home");
            }

            RequestOfferToTrainee ret = new RequestOfferToTrainee();

            ret.Id_Offer_request = offer.Id_Offer_request;
            ret.nationalId_Coash = offer.nationalId_Coash;
            ret.nationalId_User = offer.nationalId_User;
            ret.Price = offer.Price;
            ret.text = offer.text;
            ret.status = "تحت المراجعة";

            _context.requestOfferToTrainee.Add(ret);
            _context.SaveChanges();
            
            return RedirectToAction("requestOffer");
        }


        //Method
        public bool Redireact()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("UserId") != null)
            {
                if (Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("Roll")) == 1)
                {
                    return true;
                }
            }
            return false;
        }

        //Method
        public  List<Days> DayLIst()
        {
            List<Days> days = new List<Days>();

            days = _context.days.Where(x => x.Id != null).ToList();

            return days;
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

        //public ActionResult Registration()
        //{
        //    Registration NewRegistration = new Registration();
        //    NewRegistration.OrgList = PopulateOrgs();
        //    return View(NewRegistration);
        //}

        //[HttpPost]
        //public ActionResult Registration(Registration registration)
        //{
        //    ViewBag.Message = "Selected Items:\\n";
        //    string Label1 = string.Empty;

        //    foreach (SelectListItem li in registration.OrgList)
        //    {
        //        if (li.Selected == true)
        //        {
        //            ViewBag.Message += string.Format("{0}", li.Value);
        //        }
        //    }

        //    return View(registration);
        //}

        //public static List<SelectListItem> PopulateOrgs()
        //{
        //    string constr = @"data source=.; initial catalog=XProjec;integrated security=true";
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        string query = " SELECT Id, Namd,IsCheched FROM Days";
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    items.Add(new SelectListItem
        //                    {
        //                        Text = sdr["Id"].ToString(),
        //                        Value = sdr["Namd"].ToString()
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return items;
        //}



        //List<Days> Days = DayLIst();

        //foreach(Days d in Days)
        //{
        //    if (AllDaySelected.Contains(d.Id.ToString()))
        //    {
        //        if(d.IsCheched == true)
        //        {
        //            var id = d.Id;
        //        }
        //    }
        //}


    }
}
