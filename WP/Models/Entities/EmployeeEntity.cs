using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WP.Models.Entities
{
    public class EmployeeEntity
    {

        public int EmployeeID { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Roles { get; set; }
    }
}