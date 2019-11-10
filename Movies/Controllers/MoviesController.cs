using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;
using System.Data.Entity;
using Movies.ViewModels;



namespace Movies.Controllers
{
    public class MoviesController : Controller
    {



        // GET: Movies
        ApplicationDbContext _context;
        public int pageSize = 4;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }
        public ActionResult AdminList( int page)
        {
            var model = new MovieListViewModel
            {
                Movies = _context.Movies
                      .OrderBy(m => m.Id)
                      .Skip((page - 1) * pageSize)
                      .Take(pageSize),
                PagingInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _context.Movies.Count()
                }
            };

            return View("List",model );
        }

        public ViewResult Index(string category,int page)
        {
            var model = new MovieListViewModel
            {
                Movies = _context.Movies.Where(p => category == null || p.Genre == category)
                    .OrderBy(m => m.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _context.Movies.Count()
                },
                CurrentCategory = category
            };

            return View("ReadOnlyList",model);
            
        }


        [Authorize(Roles = RoleName.CanManageMovies)]

        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var viewmodel = new MovieFormViewModel();
           
            return View("MovieForm",viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]

        public ActionResult Save(Movie movie)
        {
            // var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel(movie);
               
                return View("MovieForm", viewmodel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
               
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                
            }
           
            _context.SaveChanges();
            return RedirectToAction("AdminList", "Movies", new { page = 1 });
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit( int id)
        {
            
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewmodel = new MovieFormViewModel(movie);
           
            return View("MovieForm",viewmodel);
        }
        [HttpPost]
        public ActionResult DeleteConfirm(Movie movie)
        {
            var movieINDb =_context.Movies.SingleOrDefault(m  => m.Id==movie.Id)  ;
            if (movieINDb != null)
            {
                _context.Movies.Remove(movieINDb);
                _context.SaveChanges();

                return RedirectToAction("AdminList", "Movies", new { page = 1 });
                
            }

            return HttpNotFound();
        }
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();


            return View(movie);
        }

    }
}