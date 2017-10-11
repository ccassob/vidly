using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.WebApp.Models;
using Vidly.WebApp.Validations;

namespace Vidly.WebApp.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter a name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Min18YearsOldIfMember]
        public DateTime? BirthDate { get; set; }

        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        [Display(Name = "MemberShip Types")]
        public byte MemberShipTypeId { get; set; }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer model)
        {
            Id = model.Id;
            Name = model.Name;
            BirthDate = model.BirthDate;
            IsSubscribedToNewsletter = model.IsSubscribedToNewsletter;
            MemberShipTypeId = model.MemberShipTypeId;
        }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit" : "New";
            }
        }
    }
}