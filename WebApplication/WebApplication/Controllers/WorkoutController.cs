using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;

namespace WebApplication.Controllers
{
    public class WorkoutController : Controller
    {
        private IExerciseRepository _exerciseRepository;

        private IUserRepository _userRepository;

        private IWorkoutRepository _workoutRepository;

        public WorkoutController(IExerciseRepository exerciseRepository, IUserRepository userRepository,
            IWorkoutRepository workoutRepository)
        {
            _exerciseRepository = exerciseRepository;
            _userRepository = userRepository;
            _workoutRepository = workoutRepository;
        }
        // GET: Workout
        public ActionResult Index()
        {
            var data = _workoutRepository.GetWorkouts();
            return View(data);
        }
    }
}