using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var nationalId = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserId"));

            ViewBag.openTicket = _context.trainingoffers.Where(x => x.nationalId == nationalId && x.Stutes == "مفتوح").Count();

            ViewBag.CloseTicket = _context.trainingoffers.Where(x => x.nationalId == nationalId && x.Stutes == "مغلق").Count();

            return View();
        }

        public IActionResult MyProfile()
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            var nationalId = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserId"));

            ViewBag.Info =  _context.applactionUsers
                   .Where(x => x.nationalId == nationalId).FirstOrDefault();

            // ViewBag.Info = GetAllInfo(nationalId);


            //Take it From My Sitting Action
            //var nationalId = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserId"));
            var model = _context.applactionUsers.Where(x => x.nationalId == nationalId).FirstOrDefault();


            return View(model);
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

            var Request = _context.trainingoffers.Where(x => x.nationalId.Equals(ConVertNID) && x.Stutes == "مفتوح").FirstOrDefault();

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

            var nationalId =Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserId"));
           var model = _context.applactionUsers.Where(x => x.nationalId == nationalId).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public IActionResult Settings(ApplactionUsers applactionUsers)
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            var nationalId = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserId"));
            // var model = _context.applactionUsers.Where(x => x.nationalId == nationalId).FirstOrDefault();


            //int id_ = trainingOffers.Id;
            var User = _context.applactionUsers
                .Where(x => x.nationalId == nationalId).FirstOrDefault();

            //var InfoCurrntUser = _context.applactionUsers.Find(nationalId);

            User.Password = applactionUsers.Password;
            User.Confirmpassword = applactionUsers.Confirmpassword;
            User.Name = applactionUsers.Name;
            User.Email = applactionUsers.Email;
            _context.Entry(applactionUsers).State = EntityState.Detached;
            _context.Update(User);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }

            var model = _context.trainingoffers.Where(x => x.Id == Id).FirstOrDefault();
            int nationalId = model.nationalId;

            if(nationalId == Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserId")))
            {
                ViewBag.YorRightUser = true;
            }

            ViewBag.name = GetNameByNationalID(nationalId);

            ViewBag.Roll = GetRool();



            ViewBag.AllOffer =  _context.requestOfferToTrainee.Where(x => x.status == "تحت المراجعة" && x.Id_Offer_request == Id).ToList();
           
            var NIDCoach = _context.requestOfferToTrainee.Where(x => x.status == "تحت المراجعة" && x.Id_Offer_request == Id).FirstOrDefault();

            int NIDCO;

            if (NIDCoach != null)
            {
                 NIDCO = NIDCoach.nationalId_Coash;
                ViewBag.NameCoach = _context.applactionUsers.Where(x => x.nationalId == NIDCoach.nationalId_Coash).FirstOrDefault().Name;
            }
            

            //if(NIDCO != null)
            //{
            //    ViewBag.NameCoach = _context.applactionUsers.Where(x => x.nationalId == NIDCoach.nationalId_Coash).FirstOrDefault().Name;
            //}
           

            return View(model);
        }

        [HttpPost]
        public IActionResult ChangeStutes(int Id, TrainingOffers trainingOffers)
        {
            if (ViewBag.NID = _httpContextAccessor.HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("login", "Home");
            }
            int id_ = trainingOffers.Id;
            var Offer = _context.trainingoffers.Find(id_);

            Offer.Stutes = trainingOffers.Stutes;
            _context.Entry(trainingOffers).State = EntityState.Detached;
            _context.Update(Offer);
            _context.SaveChanges();

            return RedirectToAction("Details",new { Id = id_ });
        }
            

        //Method Get Rool
        public string GetRool()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("Roll");
        }

        //Method GetNameByNationalID
        public string GetNameByNationalID(int nationalId)
        {
            return _context.applactionUsers
                .Where(x => x.nationalId == nationalId).FirstOrDefault().Name;
        }

        public List<ApplactionUsers> GetAllInfo(int nationalId)
        {
            return _context.applactionUsers
                    .Where(x => x.nationalId == nationalId).ToList();
        }
    }
}