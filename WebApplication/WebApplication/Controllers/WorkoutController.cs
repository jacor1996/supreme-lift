using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Abstract;

namespace WebApplication.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private IWorkoutRepository _workoutRepository;

        private User _user;

        public WorkoutController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        // GET: Workout
        public ActionResult Index()
        {
            var data = _workoutRepository.GetWorkouts();
            return View(data);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Workout workout)
        {
            SetUp();
            workout.User = _user;
            workout.Fk_UserId = _user.UserId;

            ModelState.Remove("WorkoutExercises");
            if (ModelState.IsValid)
            {
                _workoutRepository.AddWorkout(workout);
                return RedirectToAction("Index");
            }

            return View(workout);
        }

        private void SetUp()
        {
            string currentUser = HttpContext.User.Identity.Name;
            _user = _workoutRepository.FindUser(currentUser);
        }
    }
}