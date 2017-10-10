using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.WebApp.Validations;

namespace Vidly.WebApp.Models.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter a name")]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MemberShipTypeId { get; set; }
    }
}