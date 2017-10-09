using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.WebApp.Models;

namespace Vidly.WebApp.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Numbers in Stock")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Genre Type")]
        public byte? GenreTypeId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit" : "New";
            }

        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Stock = movie.Stock;
            GenreTypeId = movie.GenreTypeId;
            DateAdded = movie.DateAdded;
        }
    }
}