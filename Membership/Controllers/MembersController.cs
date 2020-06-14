using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Membership.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Membership.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Members
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = UserManager.FindById(HttpContext.User.Identity.GetUserId());
            ViewBag.canEdit = user.Roles.Any(x => x.RoleId == roles.First(r => r.Name == "Admin").Id || x.RoleId == roles.First(r => r.Name == "Editor").Id);

            return View(db.Members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            var statuses = db.Statuses.OrderBy(x => x.Name).ToList();
            var member = new Member();
            member.MemNum = db.Members.Max(x => x.MemNum) + 1;
            return View(new MemberViewModel(member, statuses));
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var existingMemNums = db.Members.Where(x => x.MemNum == vm.Member.MemNum);
                if (existingMemNums.Any())
                {
                    ModelState.AddModelError(string.Empty, "The MemNum must be unique");
                }
                else
                {
                    vm.Member.LastUpdate = DateTime.Now;
                    db.Members.Add(vm.Member);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            vm.Statuses = db.Statuses.ToList();

            return View(vm);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            var statuses = db.Statuses.OrderBy(x => x.Name).ToList();
            return View(new MemberViewModel(member, statuses));
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var existingMemNums = db.Members.Where(x => x.MemNum == vm.Member.MemNum);
                if (existingMemNums.Any(x => x.Id != vm.Member.Id))
                {
                    ModelState.AddModelError(string.Empty, "The MemNum must be unique");
                }
                else
                {
                    vm.Member.LastUpdate = DateTime.Now;
                    db.Entry(vm.Member).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            vm.Statuses = db.Statuses.ToList();
            return View(vm);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            var statuses = db.Statuses.OrderBy(x => x.Name).ToList();
            return View(new MemberViewModel(member, statuses));
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
