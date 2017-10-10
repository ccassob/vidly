using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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