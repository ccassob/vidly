using System.Collections.Generic;
using System.Data.Entity;
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
            var model = _context.Movies.Include(h => h.GenreType).ToList();

            return View(model);
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
        public ActionResult New()
        {
            var genretypes = _context.GenreTypes.ToList();

            var model = new MovieFormViewModel()
            {
                GenreTypes = genretypes
            };

            return View("MoviesCreateForm", model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var genretypes = _context.GenreTypes.ToList();
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            var model = new MovieFormViewModel()
            {
                GenreTypes = genretypes,
                Movies = movie
            };

            return View("MoviesCreateForm", model);
        }


        [HttpPost]
        public ActionResult Save(MovieFormViewModel model)
        {
            if (model.Movies.Id == 0)
            {
                _context.Movies.Add(model.Movies);
            }
            else
            {
                var customerInDb = _context.Movies.Single(c => c.Id == model.Movies.Id);
                customerInDb.Name = model.Movies.Name;
                customerInDb.Stock = model.Movies.Stock;
                customerInDb.DateAdded = model.Movies.DateAdded;
                customerInDb.GenreTypeId = model.Movies.GenreTypeId;
            }

            _context.SaveChanges();


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