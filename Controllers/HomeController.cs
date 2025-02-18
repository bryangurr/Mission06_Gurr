using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie NewMovie)
        {
            _context.Movies.Add(NewMovie); // Add record to database
            _context.SaveChanges();
            return View("AddMovie");
        }

        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

    }
}
