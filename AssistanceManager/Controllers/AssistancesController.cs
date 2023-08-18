using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssistanceManager;

namespace AssistanceManager.Controllers
{
    public class AssistancesController : Controller
    {
        private AssistanceManagerEntities1 db = new AssistanceManagerEntities1();

        // GET: Assistances
        public ActionResult Index()
        {
            var assistance = db.Assistance.Include(a => a.Customers).Include(a => a.Priority1);
            return View(assistance.ToList());
        }

        // GET: Assistances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assistance assistance = db.Assistance.Find(id);
            if (assistance == null)
            {
                return HttpNotFound();
            }
            return View(assistance);
        }

        // GET: Assistances/Create
        public ActionResult Create()
        {
            ViewBag.Customer = new SelectList(db.Customers, "CustomerID", "Name");
            ViewBag.Priority = new SelectList(db.Priority, "Priority1", "Priority1");
            return View();
        }

        // POST: Assistances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssistanceID,DateTime,Customer,Priority")] Assistance assistance)
        {
            if (ModelState.IsValid)
            {
                db.Assistance.Add(assistance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer = new SelectList(db.Customers, "CustomerID", "Name", assistance.Customer);
            ViewBag.Priority = new SelectList(db.Priority, "Priority1", "Priority1", assistance.Priority);
            return View(assistance);
        }

        // GET: Assistances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assistance assistance = db.Assistance.Find(id);
            if (assistance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer = new SelectList(db.Customers, "CustomerID", "Name", assistance.Customer);
            ViewBag.Priority = new SelectList(db.Priority, "Priority1", "Priority1", assistance.Priority);
            return View(assistance);
        }

        // POST: Assistances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssistanceID,DateTime,Customer,Priority")] Assistance assistance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assistance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer = new SelectList(db.Customers, "CustomerID", "Name", assistance.Customer);
            ViewBag.Priority = new SelectList(db.Priority, "Priority1", "Priority1", assistance.Priority);
            return View(assistance);
        }

        // GET: Assistances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assistance assistance = db.Assistance.Find(id);
            if (assistance == null)
            {
                return HttpNotFound();
            }
            return View(assistance);
        }

        // POST: Assistances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assistance assistance = db.Assistance.Find(id);
            db.Assistance.Remove(assistance);
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
