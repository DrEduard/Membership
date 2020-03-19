using Membership.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Membership.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var users = db.Users.ToList();
            var roles = db.Roles.ToList();
            var statuses = db.Statuses.ToList();

            return View(new UsersViewModel { Users = users, Roles = roles, Statuses = statuses });
        }

        public ActionResult CreateUser()
        {
            var vm = new UserViewModel();
            vm.Roles = db.Roles.ToList();
            return View(vm);
        }

        public ActionResult CreateStatus()
        {
            return View(new StatusViewModel());
        }

        [HttpPost]
        public ActionResult CreateStatus(StatusViewModel status)
        {
            if (ModelState.IsValid)
            {
                var existingStatus = db.Statuses.FirstOrDefault(x => x.Name == status.Name);
                if(existingStatus == null)
                {
                    db.Statuses.Add(new Status { Name = status.Name });
                    db.SaveChanges();
                }

                return RedirectToAction("Users");
            }

            return View(status);
        }

        [HttpPost]
        public ActionResult CreateUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var user = new ApplicationUser();
                user.UserName = model.Username;
                user.Email = model.Email;

                var chkUser = UserManager.Create(user, model.Password);
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, model.Role);
                }

                return RedirectToAction("Users");
            }

            return View(model);
        }

        [HttpPost, ActionName("DeleteStatus")]
        public ActionResult DeleteStatus(int id)
        {
            var status = db.Statuses.FirstOrDefault(x => x.Id == id);
            if(status != null)
            {
                db.Statuses.Remove(status);
                db.SaveChanges();
            }
            return RedirectToAction("Users");
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(string id)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = UserManager.FindById(id);
            if(user != null)
            {
                UserManager.Delete(user);
                db.SaveChanges();
            }
            return RedirectToAction("Users");
        }

    }
}