using Microsoft.AspNetCore.Mvc;
using Mission06_Gurr.Models;
using System.Diagnostics;

namespace Mission06_Gurr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() // Homepage
        {
            return View();
        }

        public IActionResult About() // About me page with links to external sites
        {
            return View();
        }
        
        public IActionResult Movies() // Form to add movie
        {
            return View();
        }

    }
}
