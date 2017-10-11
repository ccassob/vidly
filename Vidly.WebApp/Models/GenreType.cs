using System.ComponentModel.DataAnnotations;

namespace Vidly.WebApp.Models
{
    public class GenreType
    {
        public byte Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}