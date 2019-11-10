using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Movies.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ViewResult List()
        {
            string idStr = User.Identity.GetUserId();
            int id = Convert.ToInt32(idStr);
            var rentals = _context.Rentals.ToList(); 

            return View(rentals);
        }
    }
}