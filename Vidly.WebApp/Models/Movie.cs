using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.WebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded{ get; set; }
        [Display(Name = "Numbers in Stock")]
        public int Stock { get; set; }
        public byte GenreTypeId { get; set; }

    }
}