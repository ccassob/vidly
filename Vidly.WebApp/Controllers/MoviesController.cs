using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.WebApp.Models;
using Vidly.WebApp.ViewModel;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
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

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " " + month);
        }
    }
}