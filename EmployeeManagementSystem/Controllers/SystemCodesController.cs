using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Controllers
{
    public class SystemCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SystemCodes
        public ActionResult Index()
        {
            return View(db.SystemCodes.ToList());
        }

        // GET: SystemCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCode systemCode = db.SystemCodes.Find(id);
            if (systemCode == null)
            {
                return HttpNotFound();
            }
            return View(systemCode);
        }

        // GET: SystemCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,CreatedById,CreatedOn,ModifieById,ModifiedOn")] SystemCode systemCode)
        {
            if (ModelState.IsValid)
            {
                db.SystemCodes.Add(systemCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systemCode);
        }

        // GET: SystemCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCode systemCode = db.SystemCodes.Find(id);
            if (systemCode == null)
            {
                return HttpNotFound();
            }
            return View(systemCode);
        }

        // POST: SystemCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,CreatedById,CreatedOn,ModifieById,ModifiedOn")] SystemCode systemCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systemCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemCode);
        }

        // GET: SystemCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCode systemCode = db.SystemCodes.Find(id);
            if (systemCode == null)
            {
                return HttpNotFound();
            }
            return View(systemCode);
        }

        // POST: SystemCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SystemCode systemCode = db.SystemCodes.Find(id);
            db.SystemCodes.Remove(systemCode);
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
