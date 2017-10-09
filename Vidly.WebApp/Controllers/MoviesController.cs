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

            var model = new MovieFormViewModel(movie)
            {
                GenreTypes = genretypes,
            };

            return View("MoviesCreateForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie model)
        {
            if (!ModelState.IsValid)
            {
                var genretypes = _context.GenreTypes.ToList();

                var movieCreateModel = new MovieFormViewModel(model)
                {
                    GenreTypes = genretypes,
                };

                return View("MoviesCreateForm", movieCreateModel);

            }

            if (model.Id == 0)
            {
                _context.Movies.Add(model);
            }
            else
            {
                var customerInDb = _context.Movies.Single(c => c.Id == model.Id);
                customerInDb.Name = model.Name;
                customerInDb.Stock = model.Stock;
                customerInDb.DateAdded = model.DateAdded;
                customerInDb.GenreTypeId = model.GenreTypeId;
            }

            _context.SaveChanges();


            return RedirectToAction("Index");

        }
    }
}