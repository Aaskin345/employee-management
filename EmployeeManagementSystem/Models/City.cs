using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name{ get; set; }
        
        public string CountryId  { get; set; }
        public Country Country { get; set; }
    }
}