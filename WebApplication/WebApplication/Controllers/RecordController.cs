using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Abstract;
using Microsoft.AspNet.Identity;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class RecordController : Controller
    {
        private IRecordRepository _repository;
        private User _user;
        private ChartData _chartData;

        public RecordController(IRecordRepository repository)
        {
            _repository = repository;
            _chartData = new ChartData();
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

        public ActionResult Get()
        {
            SetUser();
            var currentUserRecords = _repository.GetRecords(_user);

            return View(currentUserRecords);
        }

        public ActionResult Create()
        {
            SetUser();
            ViewBag.ExercisesList = PopulateExercisesSelectList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Record record)
        {
            SetUser();
            record.Fk_UserId = _user.UserId;
            record.User = _user;
            record.Exercise = _repository.FindExercise((int)record.Fk_ExerciseId);

            if (ModelState.IsValid)
            {
                _repository.AddRecord(record);
                return RedirectToAction("Get");
            }

            return View(record);
        }

        public ActionResult Edit(int id)
        {
            SetUser();
            Record recordToEdit = _repository.FindRecord(id);
            ViewBag.ExercisesList = PopulateExercisesSelectList();

            if (recordToEdit == null || recordToEdit.User.Name != _user.Name)
            {
                return HttpNotFound("Invalid record id.");
            }

            return View(recordToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Record record)
        {
            SetUser();
            record.Fk_UserId = _user.UserId;
            record.User = _user;
            record.Exercise = _repository.FindExercise((int)record.Fk_ExerciseId);

            if (ModelState.IsValid)
            {
                _repository.AddRecord(record);
                return RedirectToAction("Get");
            }

            return View(record);
        }

        public ActionResult Delete(int id)
        {
            SetUser();

            Record recordToDelete = _repository.FindRecord(id);

            if (recordToDelete != null && _user.Name == recordToDelete.User.Name)
            {
                _repository.DeleteRecord(recordToDelete);
                return RedirectToAction("Get");
            }

            return HttpNotFound("Something went wrong.");
        }

        private ChartViewModel viewModel = new ChartViewModel();

        public ActionResult Chart()
        {
            _chartData = TempData["data"] as ChartData;
            return View(_chartData);
        }

        public ActionResult ChartData()
        {
            ViewBag.ExercisesList = PopulateExercisesSelectList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ChartData(ChartViewModel chartViewModel)
        {
            SetUser();
            viewModel.Exercise = _repository.FindExercise(chartViewModel.ExerciseId);
            viewModel.AmountOfData = chartViewModel.AmountOfData;
            viewModel.ExerciseId = chartViewModel.ExerciseId;
            viewModel.Records = _repository.GetRecords(_user).Take(viewModel.AmountOfData);

            if (ModelState.IsValid)
            {
                List<string> dates = new List<string>();
                List<double> values = new List<double>();

                foreach (Record record in viewModel.Records)
                {
                    dates.Add(record.Date.Value.ToShortDateString());
                    values.Add(record.WeightLifted);
                }

                _chartData.xValues = dates.ToArray();
                _chartData.yValues = values.ToArray();
                _chartData.seriesName = viewModel.Exercise.Name;

                TempData["data"] = _chartData;

                return RedirectToAction("Chart");
            }

            return View(chartViewModel);
        }
    }
}