using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class UserActivity
    {
        public string  CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string  ModifieById{ get; set; }
        public DateTime ModifiedOn { get; set; }

    }
    public class ApprovalActivity:UserActivity
    {
        public string ApprovedById { get; set; }
        public DateTime ApprovedOn { get; set; }
    }
}