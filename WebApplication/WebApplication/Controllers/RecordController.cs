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
    public class RecordController : Controller
    {
        private readonly IDataRepository _repository;
        private User _user;

        public RecordController(IDataRepository repository)
        {
            _repository = repository;
        }

        private void SetUser()
        {
            string userName = HttpContext.User.Identity.GetUserName();
            _user = _repository.FindUser(userName);
        }

        private SelectList PopulateExercisesSelectList()
        {
            var data = from e in _repository.GetExercises()
                select new
                {
                    Id = e.ExerciseId,
                    Name = e.Name
                };

            return new SelectList(data, "Id", "Name");
        }

        // GET: Record
        public ActionResult Index()
        {
            SetUser();
            var records = _repository.GetRecords();
            return View(records);
        }

        public ActionResult Create()
        {
            string userName = HttpContext.User.Identity.GetUserName();
            ViewBag.ExercisesList = PopulateExercisesSelectList();
            return View();
        }
    }
}