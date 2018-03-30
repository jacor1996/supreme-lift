using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Abstract;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private IDataRepository _repository;

        public UserController(IDataRepository repository)
        {
            _repository = repository;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_repository.GetUsers());
        }

        // Create: User
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.AddUser(user);
                return RedirectToAction("Index");
            }

            return HttpNotFound("User creation failed.");
        }

        //Edit
        public ActionResult Edit(int id)
        {
            User user = _repository.FindUser(id);
            if (user != null)
            {
                return View(user);
            }

            return HttpNotFound("User with specified id does not exist.");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.AddUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

    }
}