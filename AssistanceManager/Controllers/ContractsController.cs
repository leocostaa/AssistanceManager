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
    public class ContractsController : Controller
    {
        private AssistanceManagerEntities2 db = new AssistanceManagerEntities2();

        // GET: Contracts
        public ActionResult Index()
        {
            var contract = db.Contract.Include(c => c.Process1).Include(c => c.Technicians);
            return View(contract.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.Process = new SelectList(db.Process, "ProcessID", "Description");
            ViewBag.Technician = new SelectList(db.Technicians, "TechnicianID", "Name");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractID,Process,Description,DateOfOpen,DateOfClose,Technician,Status")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contract.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Process = new SelectList(db.Process, "ProcessID", "Description", contract.Process);
            ViewBag.Technician = new SelectList(db.Technicians, "TechnicianID", "Name", contract.Technician);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.Process = new SelectList(db.Process, "ProcessID", "Description", contract.Process);
            ViewBag.Technician = new SelectList(db.Technicians, "TechnicianID", "Name", contract.Technician);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractID,Process,Description,DateOfOpen,DateOfClose,Technician,Status")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Process = new SelectList(db.Process, "ProcessID", "Description", contract.Process);
            ViewBag.Technician = new SelectList(db.Technicians, "TechnicianID", "Name", contract.Technician);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contract.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contract.Find(id);
            db.Contract.Remove(contract);
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
