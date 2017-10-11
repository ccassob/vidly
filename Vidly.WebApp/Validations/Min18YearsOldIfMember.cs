using System;
using System.ComponentModel.DataAnnotations;
using Vidly.WebApp.Models;

namespace Vidly.WebApp.Validations
{
    public class Min18YearsOldIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == MemberShipType.Unknown || customer.MemberShipTypeId == MemberShipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("BirthDate is required.");
            }

            var age = DateTime.Now.Year - customer.BirthDate.Year;

            return (age > 18) ?
                ValidationResult.Success : new ValidationResult("Age must be more than 18.");
        }
    }
}