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
    public class EmployeeTypeConfiguration : EntityTypeConfiguration<EmployeeType>
    {
        public EmployeeTypeConfiguration()
        {
            ToTable("EmployeeType");
            Property(a => a.Description).IsRequired();
            Property(a => a.EnterpriseKey).IsRequired();
        }
    }
}
