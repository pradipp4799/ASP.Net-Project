﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt=validationContext.ObjectInstance as Shirt;
            if (shirt != null) { 
              if(shirt.Gender.Equals("men",StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
                {
                    return new ValidationResult("For mens shirts,the size has to be greater or equal to 8");
                }
              else if(shirt.Gender.Equals("women",StringComparison.OrdinalIgnoreCase) && shirt.Size < 6){
                    return new ValidationResult("For Women's shirts,the size has to be greater or equal to 6");
                }
            }
            return ValidationResult.Success;
        }
    }
}
