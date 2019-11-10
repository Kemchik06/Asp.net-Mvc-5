using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;


namespace Movies.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext context;
        public CartController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public RedirectToRouteResult AddToCart(int movieId, string returnUrl)
        {
            Movie movie = context.Movies
                .FirstOrDefault(g => g.Id == movieId);//находим фильм в контекстк данных по заданному id

            if (movie != null)
            {
                GetCart().AddItem(movie, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
            
        }

        public RedirectToRouteResult RemoveFromCart(int movieId, string returnUrl)
        {
            Movie movie = context.Movies
                .FirstOrDefault(g => g.Id == movieId);

            if (movie != null)
            {
                GetCart().RemoveLine(movie);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}