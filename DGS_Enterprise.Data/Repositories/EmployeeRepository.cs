using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGS_Enterprise.Data.Infrastructure;
using DGS_Enterprise.Model;

namespace DGS_Enterprise.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = this.DbContext.Employees.Where(a => a.EmployeeId == employeeId).FirstOrDefault();
            return employee;
        }
        public Employee GetEmployeeByLogin(string login)
        {
            var employee = this.DbContext.Employees.Where(a => a.LoginName == login).FirstOrDefault();
            return employee;
        }
    }
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetEmployeeById(int employeeId);
        Employee GetEmployeeByLogin(string login);
    }
}
