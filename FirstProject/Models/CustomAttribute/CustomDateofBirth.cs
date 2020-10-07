using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace FirstProject.Models.CustomAttribute
{
    public class CustomDateofBirth : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime DT = Convert.ToDateTime(value);
            if (value == null)
            {
                return new ValidationResult(" Date of Birth is Required");
            }
            if (DT > DateTime.Now)
            {
                return new ValidationResult("Date of Birth cannot be greater than today's date");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}