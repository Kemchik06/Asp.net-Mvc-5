using Movies.Models;
using Movies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class GamesController : Controller
    {
        ApplicationDbContext _context;
        public int pageSize = 4;

        public GamesController()
        {
            _context = new ApplicationDbContext();

        }
        public ActionResult AdminList(int page)
        {
            var model = new GameListViewModel
            {
                Games = _context.Games
                      .OrderBy(m => m.Id)
                      .Skip((page - 1) * pageSize)
                      .Take(pageSize),
                PagingInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _context.Games.Count()
                }
               
            };

            return View("AdminList", model);
        }
        public ViewResult Index(string category,int page)
        {
            var model = new GameListViewModel
            {
                Games = _context.Games.Where(p => category == null || p.Category == category)
                    .OrderBy(m => m.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _context.Games.Count()
                },
                CurrentCategory = category
            };

            return View("GameList", model);

        }

        [Authorize(Roles = RoleName.CanManageMovies)]

        public ActionResult Details(int? id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);
            if (game == null)
                return HttpNotFound();

            return View(game);

        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var viewmodel = new GameFormViewModel();

            return View("GameForm", viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]

        public ActionResult Save(Game game)
        {
            // var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (!ModelState.IsValid)
            {
                var viewmodel = new GameFormViewModel(game);

                return View("GameForm", viewmodel);
            }
            if (game.Id == 0)
            {
                _context.Games.Add(game);
            }

            else
            {
                var gameINDb = _context.Games.Single(c => c.Id == game.Id);
                gameINDb.Name = game.Name;
                gameINDb.Description = game.Description;
                gameINDb.Price = game.Price;
                gameINDb.Category = game.Category;
               

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Games");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {

            var game = _context.Games.SingleOrDefault(m => m.Id == id);
            if (game == null)
                return HttpNotFound();
            var viewmodel = new GameFormViewModel(game);

            return View("GameForm", viewmodel);
        }

    }
    // GET: Games
    
    
}