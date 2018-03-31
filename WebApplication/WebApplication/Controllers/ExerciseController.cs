using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Abstract;


namespace WebApplication.Controllers
{
    public class ExerciseController : Controller
    {
        private IDataRepository _repository;

        public ExerciseController(IDataRepository repository)
        {
            _repository = repository;
        }

        // GET: Exercise
        public ActionResult Index()
        {
            var data = _repository.GetExercises();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _repository.AddExercise(exercise);
                return RedirectToAction("Index");
            }

            return View(exercise);
        }
        
        public ActionResult Edit(int id)
        {
            Exercise _exercise = _repository.FindExercise(id);

            if (_exercise != null)
            {
                return View(_exercise);
            }

            return HttpNotFound("Exercise with specified id does not exist.");
        }

        [HttpPost]
        public ActionResult Edit(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _repository.AddExercise(exercise);
                return RedirectToAction("Index");
            }

            return View(exercise);
        }

        public ActionResult Delete(int id)
        {
            Exercise _exercise = _repository.FindExercise(id);

            if (_exercise != null)
            {
                _repository.DeleteExercise(_exercise);
                return RedirectToAction("Index");
            }

            return HttpNotFound("Failed to delete exercise.");
        }
    }
}