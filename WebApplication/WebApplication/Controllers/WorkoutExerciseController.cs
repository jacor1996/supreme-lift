using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Abstract;
using Microsoft.AspNet.Identity;

namespace WebApplication.Controllers
{
    [Authorize]
    public class WorkoutExerciseController : Controller
    {
        private IExerciseRepository _exerciseRepository;
        private IWorkoutRepository _workoutRepository;
        private IUserRepository _userRepository;
        private IWorkoutExerciseRepository _workoutExerciseRepository;
        private User _user;

        public WorkoutExerciseController(IExerciseRepository exerciseRepository, IWorkoutRepository workoutRepository,
            IUserRepository userRepository, IWorkoutExerciseRepository workoutExerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
            _workoutRepository = workoutRepository;
            _userRepository = userRepository;
            _workoutExerciseRepository = workoutExerciseRepository;
        }

        // GET: WorkoutExercise
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            SetUser();
            ViewBag.ExercisesList = PopulateExercisesSelectList();
            ViewBag.WorkoutsList = PopulateWorkoutSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorkoutExercise workoutExercise)
        {
            if (ModelState.IsValid)
            {
                _workoutExerciseRepository.SaveWorkoutExercise(workoutExercise);
                return RedirectToAction("Index");
            }

            return View();
        }

        private SelectList PopulateExercisesSelectList()
        {
            var data = from e in _exerciseRepository.GetExercises()
                select new
                {
                    Id = e.ExerciseId,
                    Name = e.Name
                };

            return new SelectList(data, "Id", "Name");
        }

        private SelectList PopulateWorkoutSelectList()
        {
            var data = from w in _workoutRepository.GetWorkouts(_user)
                select new
                {
                    Id = w.WorkoutId,
                    Name = w.Name
                };

            return new SelectList(data, "Id", "Name");
        }

        private void SetUser()
        {
            string userName = HttpContext.User.Identity.GetUserName();
            _user = _userRepository.FindUser(userName);
        }
    }
}