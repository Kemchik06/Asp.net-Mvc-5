using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class NavController : Controller
    {
        private ApplicationDbContext context;

        public NavController()
        {
            context = new ApplicationDbContext();
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = context.Movies
                .Select(movie => movie.Genre)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
        public PartialViewResult GameMenu()
        {
            IEnumerable<string> categories = context.Games
                .Select(game => game.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
        public PartialViewResult BookMenu()
        {
            IEnumerable<string> categories = context.Books
                .Select(book => book.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }

        // GET: Nav

    }
}