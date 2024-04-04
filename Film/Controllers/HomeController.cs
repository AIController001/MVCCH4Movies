using Film.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Film.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext Context { get; set; }

        public HomeController(MovieContext ctx)
        {
            Context = ctx;
        }
        public IActionResult Index()
        {
            var movies = Context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            return View(movies);
        }

    }
}
