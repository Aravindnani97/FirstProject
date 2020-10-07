using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstProject.ViewModel
{
    public class MovieViewModel
    {
        public  Movie Movie { get; set; }
        public IEnumerable<Genre> GetGenres { get; set; }
    }
}