using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class TwitsController : Controller
    {
        private TwitterDbContext db = new TwitterDbContext();

        // GET: Twits
        public ActionResult Index()
        {
            var twits = db.Twits.Include(t => t.Author);
            return View(twits.ToList());
        }

        public ActionResult All()
        {
            ViewBag.Authors = this.db.Users
                .Select(u => new SelectListItem
                {
                    Text = u.UserName,
                    Value = u.Id
                });
            return View("List", this.db.Twits.ToList());
        }

        public ActionResult GetByAuthor(string Authors)
        {
            var twits = this.db.Twits
                .Where(t => t.AuthorId == Authors)
                .ToList();

            return PartialView("_Twits", twits);
        }

        // GET: Twits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twit twit = db.Twits.Find(id);
            if (twit == null)
            {
                return HttpNotFound();
            }
            return View(twit);
        }

        // GET: Twits/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Twits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message,AuthorId")] Twit twit)
        {
            if (ModelState.IsValid)
            {
                db.Twits.Add(twit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email", twit.AuthorId);
            return View(twit);
        }

        // GET: Twits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twit twit = db.Twits.Find(id);
            if (twit == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email", twit.AuthorId);
            return View(twit);
        }

        // POST: Twits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message,AuthorId")] Twit twit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(twit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "Email", twit.AuthorId);
            return View(twit);
        }

        // GET: Twits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twit twit = db.Twits.Find(id);
            if (twit == null)
            {
                return HttpNotFound();
            }
            return View(twit);
        }

        // POST: Twits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Twit twit = db.Twits.Find(id);
            db.Twits.Remove(twit);
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
