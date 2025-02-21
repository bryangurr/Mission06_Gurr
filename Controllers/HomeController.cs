using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Gurr.Models;
using System.Diagnostics;

namespace Mission06_Gurr.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;

        public HomeController(MoviesContext temp) {  // Constructor
            _context = temp;
        }

        [HttpGet]
        public IActionResult Index() // Homepage
        {
            return View();
        }

        [HttpGet]
        public IActionResult About() // About me page with links to external sites
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie() // Form to add movie
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie NewMovie)
        {
            _context.Movies.Add(NewMovie); // Add record to database
            _context.SaveChanges();
            return View("Confirmation", NewMovie);
        }

        [HttpGet]
        public IActionResult Movies()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.MovieId)
                .ToList();
            return View(movies);
        }


        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = _context.Movies
                .Where(x => x.MovieId == id)
                .FirstOrDefault();

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View("AddMovie", movie);
        }
        [HttpPost]
        public IActionResult EditMovie(Movie updatedMovie)
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();
            return RedirectToAction("Movies");
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies
                .Where(x => x.MovieId == id)
                .FirstOrDefault();
            return View("ConfirmDeletion", movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
    }
}
