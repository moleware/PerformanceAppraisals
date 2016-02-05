using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using DGS_Enterprise.Model;

namespace DGS_Enterprise.Data
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employee");
            Property(a => a.EmployeeId).IsRequired();
        }
    }
}
