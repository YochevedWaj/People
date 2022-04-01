﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Data;

namespace People.Web.Controllers
{
    public class PeopleController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;";
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var repo = new PeopleRepository(_connectionString);
            var people = repo.GetAll();
            return Json(people);
        }

        [HttpPost]
        public void AddPerson(Person person)
        {
            var repo = new PeopleRepository(_connectionString);
            repo.AddPerson(person);
        }


        [HttpPost]
        public void UpdatePerson(Person person)
        {
            var repo = new PeopleRepository(_connectionString);
            repo.UpdatePerson(person);
        }

        [HttpPost]
        public void DeletePerson(int id)
        {
            var repo = new PeopleRepository(_connectionString);
            repo.DeletePerson(id);
        }
    }
}
