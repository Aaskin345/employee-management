using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class Country:UserActivity
    {
        public int Id  { get; set; }
        public string Code{ get; set; }
        public string Name { get; set; }
    }
}