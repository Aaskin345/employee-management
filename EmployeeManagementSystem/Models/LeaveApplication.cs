using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class LeaveApplication:UserActivity
    {
        public int Id { get; set; }
        [Display(Name ="Employee Name")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Display(Name = "Number of Leave Days")]
        public int NoOfDays { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Leave Duration")]
        public int DurationId { get; set; }
        public SystemCodeDetail Duration { get; set; }
        public int LeaveTypeId{ get; set; }
        public LeaveType LeaveType { get; set; }
        [Display(Name = "Notes")]
        public string Description { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }
    }
}