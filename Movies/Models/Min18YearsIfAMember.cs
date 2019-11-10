using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (ApplicationUser)validationContext.ObjectInstance;
            //if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            //    return ValidationResult.Success;
            if (user.BirthDay == null)
                return new ValidationResult("Birthday is required.");
            var age = DateTime.Today.Year - user.BirthDay.Value.Year;
            return (age >= 18) ? 
                ValidationResult.Success 
                : new ValidationResult("Customer shuold be at least 18 years old to go on a memebership. ");
        }
    }
}