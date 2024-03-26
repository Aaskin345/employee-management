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
            ViewBag.DurationId = new SelectList(db.SystemCodeDetails.Include(x=>x.SystemCode).Where(y=>y.SystemCode.Code =="LeaveDuration"), "Id", "Description");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName");
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name");
       
            return View();
        }

        // POST: LeaveApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveApplication leaveApplication)
        {
            var pendingStatus = db.SystemCodeDetails
                .Include(x => x.SystemCode)
                .FirstOrDefault(y => y.Code == "Pending" && y.SystemCode.Code == "LeaveApplicationStatus");

            if (pendingStatus != null && ModelState.IsValid)
            {
                leaveApplication.CreatedOn = DateTime.Now;
                leaveApplication.CreatedById = "Kirui Kevin";
                leaveApplication.StatusId = pendingStatus.Id; // Assuming "Id" is the property holding the ID
                db.LeaveApplications.Add(leaveApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.DurationId = new SelectList(db.SystemCodeDetails.Include(x => x.SystemCode).Where(y => y.SystemCode.Code == "LeaveDuration"), "Id", "Description", leaveApplication.DurationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", leaveApplication.EmployeeId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name", leaveApplication.LeaveTypeId);
           
            return View(leaveApplication);
        }

        // GET: LeaveApplications/Edit/5
        public ActionResult Edit(int? id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pendingStatus = db.SystemCodeDetails
              .Include(x => x.SystemCode)
              .FirstOrDefault(y => y.Code == "Pending" && y.SystemCode.Code == "LeaveApplicationStatus");
            LeaveApplication leaveApplication = db.LeaveApplications.Find(id);
            if (leaveApplication == null)
            {
                leaveApplication.StatusId = pendingStatus.Id;
                return HttpNotFound();
            }
            ViewBag.DurationId = new SelectList(db.SystemCodeDetails.Include(x => x.SystemCode).Where(y => y.SystemCode.Code == "LeaveDuration"), "Id", "Description", leaveApplication.DurationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", leaveApplication.EmployeeId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name", leaveApplication.LeaveTypeId);
           
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
                var pendingStatus = db.SystemCodeDetails
              .Include(x => x.SystemCode)
              .FirstOrDefault(y => y.Code == "Pending" && y.SystemCode.Code == "LeaveApplicationStatus");
                leaveApplication.StatusId = pendingStatus.Id;
                db.Entry(leaveApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurationId = new SelectList(db.SystemCodeDetails.Include(x => x.SystemCode).Where(y => y.SystemCode.Code == "LeaveDuration"), "Id", "Description", leaveApplication.DurationId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", leaveApplication.EmployeeId);
            ViewBag.LeaveTypeId = new SelectList(db.LeaveTypes, "Id", "Name", leaveApplication.LeaveTypeId);
       
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
