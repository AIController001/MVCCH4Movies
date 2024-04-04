using Film.Models;
using Microsoft.AspNetCore.Mvc;

namespace Film.Controllers
{
    public class MovieController : Controller
    {
        public MovieContext Context { get; set; }

        public MovieController(MovieContext ctx)
        {
            Context = ctx;   
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add new movie";
            ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new Movie());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Movie";
            //Linq query to find the movie with the given id - PK search
            var movie = Context.Movies.Find(id);
            ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            //Either add a movie or edit a movie
            if(ModelState.IsValid)
            {
                if(movie.MovieId == 0)
                {
                    Context.Add(movie);
                }
                else
                {
                    Context.Update(movie);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Show our validation errors
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
                return View(movie);
            }
        }
        
        //id parameter is sent from the URL
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = Context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            Context.Remove(movie);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
