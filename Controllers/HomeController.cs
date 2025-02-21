using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Gurr.Models;
using System.Diagnostics;

namespace Mission06_Gurr.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;

        public HomeController(MoviesContext temp) { 
            _context = temp; // Constructor
        }

        [HttpGet]
        public IActionResult Index() 
        {
            // Homepage
            return View();
        }

        [HttpGet]
        public IActionResult About() 
        {
            // About me page with links to external sites
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie() 
        {
            // Form to add movie

            // Grab categories to populate dropdown
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie NewMovie)
        {
            // Add new movie to database
            _context.Movies.Add(NewMovie); 
            _context.SaveChanges();
            return View("Confirmation", NewMovie);
        }

        [HttpGet]
        public IActionResult Movies()
        {
            // Get all movies and send them to the Movies view to create table
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.MovieId)
                .ToList();
            return View(movies);
        }


        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            // Find movie in db
            var movie = _context.Movies
                .Where(x => x.MovieId == id)
                .FirstOrDefault();

            // Include categories for dropdown
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            // Send user to edit movie page with movie info pre-loaded
            return View("AddMovie", movie);
        }
        [HttpPost]
        public IActionResult EditMovie(Movie updatedMovie)
        {
            // Save edits to db
            _context.Update(updatedMovie);
            _context.SaveChanges();
            return RedirectToAction("Movies");
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            // Send user to confirmation page to verify deletion
            var movie = _context.Movies
                .Where(x => x.MovieId == id)
                .FirstOrDefault();
            return View("ConfirmDeletion", movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            // User confirmed, delete the movie 
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
    }
}
