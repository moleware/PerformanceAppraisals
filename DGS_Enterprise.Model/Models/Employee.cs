using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS_Enterprise.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int GuideBookEmployeeDepartmentId { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
    }
}
