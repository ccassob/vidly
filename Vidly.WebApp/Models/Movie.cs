using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.WebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded{ get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Numbers in Stock")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Genre Type")]
        public byte GenreTypeId { get; set; }

        public GenreType GenreType{ get; set; }

    }
}