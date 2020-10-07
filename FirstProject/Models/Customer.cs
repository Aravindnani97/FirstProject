using FirstProject.Models.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FirstProject.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Please enter the Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name="Date of Birth")]
        [CustomDateofBirth]
        public DateTime? DateofBirth{ get; set; }

        [Required]
        public string Gender { get; set; }

        [Required (ErrorMessage ="Please enter your Address")]
        
        public string Address { get; set; }
        public Membership Membership { get; set; }

        [Required]
        public int MembershipId { get; set; }
    }
}