using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.WebApp.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int Stock { get; set; }

        [Required]
        public byte GenreTypeId { get; set; }
    }
}