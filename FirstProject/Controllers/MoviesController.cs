using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FirstProject.ViewModel;

namespace FirstProject.Controllers
{
    [RoutePrefix("Movies")]
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext dbContext = null;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if(dbContext!=null)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult Index()
        {
            //return Content("this a content from movies page");
            //return HttpNotFound();
            //var movie = new Movie
            //{
            //    id = 1,
            //    Name = "V movie",
            //    ReleaseDate = DateTime.Now
            List<Movie> movies = GetMovies();
            return View(movies);
        }
            
        
    
        //public ActionResult GetMovieByid(int movieId)
        //{
        //    return Content("Getting Movie By Id:" + movieId);
        //}
        //[Route("SearchMovie/{name?}/{releaseDate?}")]
        //public ActionResult SearchMovie(string name,DateTime? releaseDate)
        //{
        //    if(string.IsNullOrEmpty(name))
        //    {
        //        name = "Eega";
        //    }
        //    if(!releaseDate.HasValue)
        //    {
        //        releaseDate = DateTime.Now;
        //    }
        //    return Content($"Movie Name:{name} Release Date:{releaseDate.Value}");
        //}
        //[Route("Search_Movie/{id}")]
        //public ActionResult SearchMovie(int id)
        //{
        //    return Content("Searching Movie By Id:" + id);
        //}

        [HttpGet]
        public ActionResult Details(int id)
        {
            //LINQ
            //var movie = (from m in GetMovies()
            //             where m.id.Equals(id)
            //             select m).FirstOrDefault();
            //return View(movie);

            //Lamda Concept =>

            //var movie = GetMovies().FirstOrDefault(x => x.id == id);
            var movie = dbContext.Movies.Include(m => m.Genre).FirstOrDefault(x => x.id == id);
            return View(movie);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new MovieViewModel
            {
                Movie = new Movie(),
            GetGenres = dbContext.Genres.ToList(),
        };
            return View("CreateNew", viewModel);
        }

        [HttpPost]

        public ActionResult Create(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = new Movie(),
                    GetGenres = dbContext.Genres.ToList(),
                };
                return View("CreateNew", viewModel);

            }
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(x => x.id == id);
            if(movie!=null)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    GetGenres = dbContext.Genres.ToList()
                };
                return View(viewModel);
            }
            return HttpNotFound("Movie Id Does Not Exist");
        }
        [HttpPost]
        public ActionResult Edit(int id,Movie movie)
        {
            var MovieDb = dbContext.Movies.SingleOrDefault(x => x.id == id);
            if(MovieDb!=null)
            {
                MovieDb.Name = movie.Name;
                MovieDb.DirectorName = movie.DirectorName;
                MovieDb.ReleaseDate = movie.ReleaseDate;
                MovieDb.GenreId = movie.GenreId;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            return HttpNotFound();
        }
        public ActionResult Test()
        {
            object Name = "Aravind";
            return View(Name);
        }

        public ActionResult Test2()
        {
            ViewBag.Name = "Revanth";
            return View();
        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(m => m.id == id);
            if (movie != null)
            {
                dbContext.Movies.Remove(movie);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            return HttpNotFound();
        }
        [NonAction]
        public List<Movie> GetMovies()
        {      
            return dbContext.Movies.ToList();
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetGenreNames()
        {
            var genres = dbContext.Genres.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.GenreName,
                Value = x.Id.ToString()
            }) ;
            return genres;
        }

    }

}