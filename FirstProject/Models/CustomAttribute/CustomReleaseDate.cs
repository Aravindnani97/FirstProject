using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FirstProject.Models.CustomAttribute;

namespace FirstProject.Models.CustomAttribute
{
    public class CustomReleaseDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime DT = Convert.ToDateTime(value);
            if(value==null)
            {
                return new ValidationResult("Release Date is Required");
            }
            if(DT>DateTime.Now)
            {
                return new ValidationResult("Release Date cannot be greater than today's date");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}