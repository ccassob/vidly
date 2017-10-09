using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.WebApp.Validations;

namespace Vidly.WebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter a name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        [Min18YearsOldIfMember]
        public DateTime BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name = "MemberShip Types")]
        public byte MemberShipTypeId { get; set; }
    }

}