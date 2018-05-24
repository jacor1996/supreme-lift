using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class StrengthController : Controller
    {
        // GET: Strength
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Squat()
        {
            return View();
        }

        public ActionResult Deadlift()
        {
            return View();
        }

        public ActionResult Bench()
        {
            return View();
        }

        public ActionResult Press()
        {
            return View();
        }
    }
}