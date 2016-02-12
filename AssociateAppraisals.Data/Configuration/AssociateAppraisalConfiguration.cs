using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Data
{
    public class AssociateAppraisalConfiguration : EntityTypeConfiguration<AssociateAppraisal>
    {
        public AssociateAppraisalConfiguration()
        {
            ToTable("AssociateAppraisal");
            Property(a => a.AppraisalId).IsRequired();
            Property(a => a.EmployeeId).IsRequired();
            Property(a => a.PracticeGroupId).IsOptional();
        }
    }
}
