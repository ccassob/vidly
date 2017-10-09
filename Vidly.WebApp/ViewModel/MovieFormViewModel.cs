using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.WebApp.Models;

namespace Vidly.WebApp.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }
        public Movie Movies { get; set; }
    }
}