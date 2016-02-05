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
    public class AppraisalConfiguration : EntityTypeConfiguration<Appraisal>
    {
        public AppraisalConfiguration()
        {
            ToTable("Appraisal");
            Property(a => a.ReviewYear).IsRequired();
            Property(a => a.StartDate).IsRequired();
            Property(a => a.EndDate).IsRequired();
        }
    }
}
