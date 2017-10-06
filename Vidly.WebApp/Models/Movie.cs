using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.WebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded{ get; set; }
        public int Stock { get; set; }
    }
}