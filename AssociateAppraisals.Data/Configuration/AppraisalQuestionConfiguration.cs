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
    public class AppraisalQuestionConfiguration : EntityTypeConfiguration<AppraisalQuestion>
    {
        public AppraisalQuestionConfiguration()
        {
            ToTable("AppraisalQuestion");
            Property(a => a.AppraisalId).IsRequired();
            Property(a => a.AppraisalQuestionGroupId).IsOptional();
            Property(a => a.AppraisalQuestionTypeId).IsRequired();
            Property(a => a.Question).IsRequired().HasMaxLength(100);
            Property(a => a.QuestionNumber).IsRequired();
        }
    }
}
