﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Abstract;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: User
        public ActionResult Index()
        {
            ViewBag.CurrentUser = _repository.FindUser(User.Identity.Name);
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
            string currentUser = HttpContext.User.Identity.Name;

            if (user != null && user.Name == currentUser)
            {
                return View(user);
            }

            return HttpNotFound("User with specified id does not exist or you are trying to edit not your data.");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            ModelState.Remove("Name");
            if (ModelState.IsValid)
            {
                user.Name = _repository.FindUser(user.UserId).Name;
                _repository.AddUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = _repository.FindUser(id);

            if (user != null)
            {
                _repository.DeleteUser(user);
                return RedirectToAction("Index");
            }

            return HttpNotFound("User with specified id does not exist.");
        }

        public enum Sex
        {
            Male = 0,
            Female = 1
        };

    }
}