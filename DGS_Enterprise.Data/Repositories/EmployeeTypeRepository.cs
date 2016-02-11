using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGS_Enterprise.Data.Infrastructure;
using DGS_Enterprise.Model;

namespace DGS_Enterprise.Data.Repositories
{
    public class EmployeeTypeRepository : RepositoryBase<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public List<EmployeeType> GetEmployeeTypes(int employeeId)
        {
            var employee = this.DbContext.Employees.Where(a => a.EmployeeID == employeeId).FirstOrDefault();
            return employee.EmployeeTypes.ToList();
        }
    }
    public interface IEmployeeTypeRepository : IRepository<EmployeeType>
    {
        List<EmployeeType> GetEmployeeTypes(int employeeId);
    }
}
