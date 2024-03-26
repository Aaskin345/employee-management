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
    public class LeaveApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LeaveApplications
        public ActionResult Index()
        {
            var leaveApplications = db.LeaveApplications.Include(l => l.Duration).Include(l => l.Employee).Include(l => l.LeaveType).Include(l => l.Status);
            return View(leaveApplications.ToList());
        }

        // GET: LeaveApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplication leaveApplication = db.LeaveApplications.Find(id);
            if (leaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplication);
        }

        // GET: LeaveApplications/Create
        public ActionResult Create()
        {
            ViewBag.DurationId = new SelectList(db.SystemCodeDetails, "Id", "Code");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmpNo");
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Code");
            ViewBag.StatusId = new SelectList(db.SystemCodeDetails, "Id", "Code");
            return View();
        }

        // POST: LeaveApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,NoOfDays,StartDate,EndDate,DurationId,LeaveTypeId,Description,StatusId,CreatedById,CreatedOn,ModifieById,ModifiedOn")] LeaveApplication leaveApplication)
        {
            if (ModelState.IsValid)
            {
                db.LeaveApplications.Add(leaveApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DurationId = new SelectList(db.SystemCodeDetails, "Id", "Code", leaveApplication.DurationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmpNo", leaveApplication.EmployeeId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Code", leaveApplication.LeaveTypeId);
            ViewBag.StatusId = new SelectList(db.SystemCodeDetails, "Id", "Code", leaveApplication.StatusId);
            return View(leaveApplication);
        }

        // GET: LeaveApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplication leaveApplication = db.LeaveApplications.Find(id);
            if (leaveApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.DurationId = new SelectList(db.SystemCodeDetails, "Id", "Code", leaveApplication.DurationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmpNo", leaveApplication.EmployeeId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Code", leaveApplication.LeaveTypeId);
            ViewBag.StatusId = new SelectList(db.SystemCodeDetails, "Id", "Code", leaveApplication.StatusId);
            return View(leaveApplication);
        }

        // POST: LeaveApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,NoOfDays,StartDate,EndDate,DurationId,LeaveTypeId,Description,StatusId,CreatedById,CreatedOn,ModifieById,ModifiedOn")] LeaveApplication leaveApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurationId = new SelectList(db.SystemCodeDetails, "Id", "Code", leaveApplication.DurationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "EmpNo", leaveApplication.EmployeeId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Code", leaveApplication.LeaveTypeId);
            ViewBag.StatusId = new SelectList(db.SystemCodeDetails, "Id", "Code", leaveApplication.StatusId);
            return View(leaveApplication);
        }

        // GET: LeaveApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplication leaveApplication = db.LeaveApplications.Find(id);
            if (leaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplication);
        }

        // POST: LeaveApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveApplication leaveApplication = db.LeaveApplications.Find(id);
            db.LeaveApplications.Remove(leaveApplication);
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
