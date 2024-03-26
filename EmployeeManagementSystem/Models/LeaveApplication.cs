using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class LeaveApplication:UserActivity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
     
        public Employee Employee { get; set; }
        public int NoOfDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationId { get; set; }
        public SystemCodeDetail Duration { get; set; }
        public int LeaveTypeId{ get; set; }
        public LeaveType LeaveType { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }
    }
}