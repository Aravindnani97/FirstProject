using FirstProject.Models.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstProject.Models
{
    public class Movie
    {
        public int id { get; set; }

       [Display(Name="Movie Name")]
       [Required(ErrorMessage ="Please Enter Movie Name")]
       [StringLength(100)]
        public string Name { get; set; }

        [Display(Name="Director Name")]
        [Required(ErrorMessage ="Please Enter the Director Name")]
        [StringLength(100)]
        public string DirectorName { get; set; }

        [Display(Name = "Release Date")]
        [CustomReleaseDate]
        public DateTime? ReleaseDate { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]

        public int GenreId { get; set; }
       
    }
}   