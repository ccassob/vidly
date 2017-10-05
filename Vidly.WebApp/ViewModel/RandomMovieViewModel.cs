using System.Collections.Generic;
using Vidly.WebApp.Models;

namespace Vidly.WebApp.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}