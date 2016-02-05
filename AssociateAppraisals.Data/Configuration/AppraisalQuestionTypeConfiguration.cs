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
    public class AppraisalQuestionTypeConfiguration : EntityTypeConfiguration<AppraisalQuestionType>
    {
        public AppraisalQuestionTypeConfiguration()
        {
            ToTable("AppraisalQuestionType");
            Property(a => a.QuestionType).IsRequired().HasMaxLength(20);
        }
    }
}
