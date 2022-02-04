﻿using M4MovieDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace M4MovieDB.Controllers
{
    public class HomeController : Controller
    {
        private MovieInputContext _MiContext { get; set; }
        public HomeController(MovieInputContext someName)
        {
            _MiContext = someName;
        }

        //index page view
        public IActionResult Index()
        {
            return View();
        }

        // Get results
        [HttpGet]
        public IActionResult MovieInput()
        {
            ViewBag.Category = _MiContext.Category.ToList();

            return View(new Movie());
        }

        //post results if valid
        [HttpPost]
        public IActionResult MovieInput(Movie ar)
        {
            if (ModelState.IsValid) //if valid
            {
                _MiContext.Add(ar);
                _MiContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else //if invalid
            {
                ViewBag.Category = _MiContext.Category.ToList();

                return View(ar);
            }
        }

        //podcast view
        public IActionResult MyPodcasts()
        {
            return View();
        }

        //Movie List (of database)
        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = _MiContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }
        //set up edit function
        [HttpGet]
        public IActionResult Edit (int MovId)
        {

            ViewBag.Category = _MiContext.Category.ToList();

            var application = _MiContext.responses.Single(x => x.MovieId == MovId);

            return View("MovieInput", application);
        }
        // edit entry
        [HttpPost]
        public IActionResult Edit (Movie info)
        {
            _MiContext.Update(info);
            _MiContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        //set up delete
        [HttpGet]
        public IActionResult Delete (int MovId)
        {
            var application = _MiContext.responses.Single(x => x.MovieId == MovId);

            return View(application);
        }
        //delete entry
        [HttpPost]
        public IActionResult Delete(Movie mov)
        {
            _MiContext.responses.Remove(mov);
            _MiContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
