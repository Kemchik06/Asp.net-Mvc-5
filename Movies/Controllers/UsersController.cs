using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<ApplicationUser> UserManager { get; set; }
        public UsersController()
        {
            context = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }
        // GET: User
        public ActionResult ListOfUsers()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        public ActionResult Edit(string id)

        {
            var user = context.Users.SingleOrDefault(m => m.Id == id);

            if (user == null)
                return HttpNotFound();
            var viewmodel = new RegisterViewModel
            {
                
                Email = user.Email,
                Name = user.Name,
                BirthDay = user.BirthDay,
                IsSubscribedToNewsletter = user.IsSubscribedToNewsletter,
                DrivingLicense = user.DrivingLicense,
                Phone = user.Phone,
                


            };
            return View("UserForm", viewmodel);
        }
        [HttpPost]
        public async Task<ActionResult> Save(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RegisterViewModel
                {
                    
                    Email = user.Email,
                    Name = user.Name,
                    BirthDay = user.BirthDay,
                    IsSubscribedToNewsletter = user.IsSubscribedToNewsletter,
                    DrivingLicense = user.DrivingLicense,
                    Phone = user.Phone,
                };
                return View("UserForm", viewModel);
            }
            if (user.Id == null)
                context.Users.Add(user);
            else
            {
               // var userInDb = UserManager.Users.FirstOrDefault(u => u.Id == user.Id);
                //  var userInDb =  UserManager.FindById(user.Id);
               var userInDb = await UserManager.FindByEmailAsync(user.Email); 
                //   var userInDb = context.Users.Single(c => c.Id == user.Id);
                userInDb.Name = user.Name;
                userInDb.BirthDay = user.BirthDay;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                userInDb.IsSubscribedToNewsletter = user.IsSubscribedToNewsletter;
                userInDb.Email = user.Email;
                userInDb.Phone = user.Phone;
                userInDb.DrivingLicense = user.DrivingLicense;


            }
            context.SaveChanges();
            return RedirectToAction("ListOfUsers", "Users");
        }

        public ActionResult Delete(string id)
        {
            var user = context.Users.SingleOrDefault(m => m.Id==id);
            if (user == null)
                return HttpNotFound();
            

            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteConfirm(ApplicationUser user)
        {
            var userInDb = await UserManager.FindByEmailAsync(user.Email);
            if (userInDb != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(userInDb);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListOfUsers", "Users");
                }
            }

            return HttpNotFound();
        }
        public async Task<ActionResult> CurrUser()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
                return HttpNotFound();
            var viewmodel = new RegisterViewModel
            {

                Email = user.Email,
                Name = user.Name,
                BirthDay = user.BirthDay,
                IsSubscribedToNewsletter = user.IsSubscribedToNewsletter,
                DrivingLicense = user.DrivingLicense,
                Phone = user.Phone,



            };
            return View("UserForm", viewmodel);
        }
    }
}