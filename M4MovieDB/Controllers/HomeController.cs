using M4MovieDB.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieInputContext _blahContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieInputContext someName)
        {
            _logger = logger;
            _blahContext = someName;
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
            return View();
        }

        //post results if valid
        [HttpPost]
        public IActionResult MovieInput(Movie ar)
        {
            if (ModelState.IsValid)
            {
                _blahContext.Add(ar);
                _blahContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                return View(ar);
            }
        }

        //podcast view
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
