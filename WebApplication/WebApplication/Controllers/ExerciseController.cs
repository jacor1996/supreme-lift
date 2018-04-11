using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Abstract;
using PagedList;


namespace WebApplication.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IDataRepository _repository;

        public ExerciseController(IDataRepository repository)
        {
            _repository = repository;
        }

        // GET: Exercise
        public ActionResult Index(int? page)
        {
            var data = _repository.GetExercises();
            var pageNumber = page ?? 1;
            var onePageofData = data.ToPagedList(pageNumber, 5);
            ViewBag.OnePageOfData = onePageofData;

            return View();
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
            Exercise exercise = _repository.FindExercise(id);

            if (exercise != null)
            {
                return View(exercise);
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
            Exercise exercise = _repository.FindExercise(id);

            if (exercise != null)
            {
                _repository.DeleteExercise(exercise);
                return RedirectToAction("Index");
            }

            return HttpNotFound("Failed to delete exercise.");
        }
    }
}