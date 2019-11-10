using Movies.Models;
using Movies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        ApplicationDbContext _context;
        public int pageSize = 4;

        public BooksController()
        {
            _context = new ApplicationDbContext();

        }
        public ActionResult AdminList(int page)
        {
            var model = new AudioBookListViewModel
            {
                AudioBooks = _context.Books
                      .OrderBy(m => m.Id)
                      .Skip((page - 1) * pageSize)
                      .Take(pageSize),
                PagingInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _context.Books.Count()
                }
            };

            return View("AdminList", model);
        }

        public ViewResult Index(string category, int page)
        {
            var model = new AudioBookListViewModel
            {
                AudioBooks = _context.Books.Where(p => category == null || p.Category == category)
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

            return View("BookList", model);

        }


        [Authorize(Roles = RoleName.CanManageMovies)]

        public ActionResult Details(int? id)
        {
            var movie = _context.Books.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var viewmodel = new AudioBookFormViewModel();

            return View("BookForm", viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]

        public ActionResult Save(AudioBook audioBook)
        {
            // var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (!ModelState.IsValid)
            {
                var viewmodel = new AudioBookFormViewModel(audioBook);

                return View("BookForm", viewmodel);
            }
            if (audioBook.Id == 0)
            {
                _context.Books.Add(audioBook);
            }

            else
            {
                var booInDb = _context.Books.Single(c => c.Id == audioBook.Id);
                booInDb.Name = audioBook.Name;
                booInDb.Category = audioBook.Category;
                booInDb.Description = audioBook.Description;
                booInDb.Price = audioBook.Price;

            }

            _context.SaveChanges();
            return RedirectToAction("AdminList", "Books", new { page = 1 });
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {

            var audioBook = _context.Books.SingleOrDefault(m => m.Id == id);
            if (audioBook == null)
                return HttpNotFound();
            var viewmodel = new AudioBookFormViewModel(audioBook);

            return View("BookForm", viewmodel);
        }
        [HttpPost]
        public ActionResult DeleteConfirm(AudioBook audioBook)
        {
            var bookInDb = _context.Books.SingleOrDefault(m => m.Id == audioBook.Id);
            if (bookInDb != null)
            {
                _context.Books.Remove(bookInDb);
                _context.SaveChanges();

                return RedirectToAction("AdminList", "Books", new { page = 1 });

            }

            return HttpNotFound();
        }
        public ActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(m => m.Id == id);
            if (book == null)
                return HttpNotFound();


            return View(book);
        }
    }
}