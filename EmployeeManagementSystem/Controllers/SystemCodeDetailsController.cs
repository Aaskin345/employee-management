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
    public class SystemCodeDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SystemCodeDetails
        public ActionResult Index()
        {
            var systemCodeDetails = db.SystemCodeDetails.Include(s => s.SystemCode);
            return View(systemCodeDetails.ToList());
        }

        // GET: SystemCodeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCodeDetail systemCodeDetail = db.SystemCodeDetails.Find(id);
            if (systemCodeDetail == null)
            {
                return HttpNotFound();
            }
            return View(systemCodeDetail);
        }

        // GET: SystemCodeDetails/Create
        public ActionResult Create()
        {
            ViewBag.SystemCodeId = new SelectList(db.SystemCodes, "Id", "Code");
            return View();
        }

        // POST: SystemCodeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SystemCodeId,Code,Description,OrderNo,CreatedById,CreatedOn,ModifieById,ModifiedOn")] SystemCodeDetail systemCodeDetail)
        {
            if (ModelState.IsValid)
            {
                db.SystemCodeDetails.Add(systemCodeDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SystemCodeId = new SelectList(db.SystemCodes, "Id", "Code", systemCodeDetail.SystemCodeId);
            return View(systemCodeDetail);
        }

        // GET: SystemCodeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCodeDetail systemCodeDetail = db.SystemCodeDetails.Find(id);
            if (systemCodeDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.SystemCodeId = new SelectList(db.SystemCodes, "Id", "Code", systemCodeDetail.SystemCodeId);
            return View(systemCodeDetail);
        }

        // POST: SystemCodeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SystemCodeId,Code,Description,OrderNo,CreatedById,CreatedOn,ModifieById,ModifiedOn")] SystemCodeDetail systemCodeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systemCodeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SystemCodeId = new SelectList(db.SystemCodes, "Id", "Code", systemCodeDetail.SystemCodeId);
            return View(systemCodeDetail);
        }

        // GET: SystemCodeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemCodeDetail systemCodeDetail = db.SystemCodeDetails.Find(id);
            if (systemCodeDetail == null)
            {
                return HttpNotFound();
            }
            return View(systemCodeDetail);
        }

        // POST: SystemCodeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SystemCodeDetail systemCodeDetail = db.SystemCodeDetails.Find(id);
            db.SystemCodeDetails.Remove(systemCodeDetail);
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
