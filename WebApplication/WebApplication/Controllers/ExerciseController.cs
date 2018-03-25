using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;


namespace WebApplication.Controllers
{
    public class ExerciseController : Controller
    {
        private IUserRepository repository;

        public ExerciseController(IUserRepository repository)
        {
            this.repository = repository;
        }

        // GET: Exercise
        public ActionResult Index()
        {
            var data = repository.GetExercises();
            return View(data);
        }


    }
}