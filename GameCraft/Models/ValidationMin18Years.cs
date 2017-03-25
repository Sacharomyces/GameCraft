using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCraft.Models
{
    public class ValidationMin18Years:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            
            if (customer.MembershipTypeId == MembershipType.Unknown ||customer.MembershipTypeId == MembershipType.PayAsGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Pole wymagane");

            var months = DateTime.Today.Month - customer.BirthDate.Value.Month;
            var years = DateTime.Today.Year - customer.BirthDate.Value.Year ;

            if (years > 18) 
                 return ValidationResult.Success;

            if (years == 18)
                return months >= 0
                    ? ValidationResult.Success
                    : new ValidationResult("Klient musi mieć ukończone 18 lat.");

            return new ValidationResult("Klient musi mieć ukończone 18 lat.");

        }
    }
}