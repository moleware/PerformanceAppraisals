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
    public class AssociateAppraisalQuestionAnswerConfiguration : EntityTypeConfiguration<AssociateAppraisalQuestionAnswer>
    {
        public AssociateAppraisalQuestionAnswerConfiguration()
        {
            ToTable("AssociateAppraisalQuestionAnswer");
            Property(a => a.AppraisalQuestionId).IsRequired();
            Property(a => a.AssociateAppraisalId).IsRequired();
            Property(a => a.Answer).IsOptional().HasMaxLength(255);
        }
    }
}
