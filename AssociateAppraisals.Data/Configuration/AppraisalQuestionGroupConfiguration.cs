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
    public class AppraisalQuestionGroupConfiguration : EntityTypeConfiguration<AppraisalQuestionGroup>
    {
        public AppraisalQuestionGroupConfiguration()
        {
            ToTable("AppraisalQuestionGroup");
            Property(a => a.Description).IsOptional().HasMaxLength(100);
        }
    }
}
