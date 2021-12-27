using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WP.Models.EFModels;
using WP.Models.Entities;
using WP.Models.Interfeces;

namespace WP.Models.Repositories
{
    public class SecurityRepository: ISecRepository//utilize repository to access the database
    {
        //Constructor
        private AppDbContext db;
        public SecurityRepository()
        {
            this.db = new AppDbContext();
        }
        //

        //Get data from EF model objects into Entity object
        public EmployeeEntity Load(string account)
        {
            Employee emp = db.Employees.SingleOrDefault(x=> x.Account == account);

            if (emp == null) { return null; };

            return new EmployeeEntity 
            { 
                EmployeeID = emp.EmployeeID, 
                Account=emp.Account, 
                Password=emp.Password,
                Roles=emp.Roles
            };
        }
        //
    }
}