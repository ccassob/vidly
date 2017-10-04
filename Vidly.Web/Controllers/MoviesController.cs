using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Web.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            return View();
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +" "+ month);
        }
    }
}