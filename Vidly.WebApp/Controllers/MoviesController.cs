using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.WebApp.Models;
using Vidly.WebApp.ViewModel;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movies = _context.Movies.ToList();

            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>() {
                new Customer { Name = "Christopher"},
                new Customer { Name = "Juana"}
            };

            var randomviewmodel = new RandomMovieViewModel
            {

                Customers = customers,
                Movie = movie
            };

            return View(randomviewmodel);
        }

        [HttpGet]
        public ActionResult Save()
        {


            return RedirectToAction("Index");
        }




        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " " + month);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            return View(movie);
        }
    }
}