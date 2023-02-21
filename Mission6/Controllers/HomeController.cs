using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieInfoContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieInfoContext movieInfo)
        {
            _logger = logger;
            _movieContext = movieInfo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _movieContext.categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(Movie movie)
        {
            // Check form validity before allowing changes
            if (ModelState.IsValid)
            {
                _movieContext.Add(movie);
                _movieContext.SaveChanges();

                return View();
            }
            else // Redirect if invalid
            {
                ViewBag.Categories = _movieContext.categories.ToList();
                return View(movie);
            }
            
        }
        public IActionResult MovieList()
        {

            ViewBag.Categories = _movieContext.categories.ToList();
            var movies = _movieContext.movies.ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _movieContext.categories.ToList();
            var movie = _movieContext.movies.Single(m => m.MovieId == movieid);

            return View("EnterMovie", movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            // Check form validity before allowing changes
            if (ModelState.IsValid)
            {
                _movieContext.Update(movie);
                _movieContext.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else // Redirect if invalid
            {
                ViewBag.Categories = _movieContext.categories.ToList();
                return View(movie);
            }
        }

        [HttpGet]
        public IActionResult Delete(int movieid) // Confirmation page for deleting a movie
        {
            var movie = _movieContext.movies.Single(m => m.MovieId == movieid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _movieContext.movies.Remove(movie);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
