using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    class Accounts
    {

        public string EmployeeUser { get; private set; }
        public string EmployeePass { get; private set; }
        public string AdminUser { get; private set; }
        public string AdminPass { get; private set; }

        public Accounts()
        {
            EmployeeUser = "employee";
            EmployeePass = "emp123";
            AdminUser = "admin";
            AdminPass = "admin123";
        }

    }
}
