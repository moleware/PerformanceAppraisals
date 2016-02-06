using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociateAppraisals.Model
{
    public class AppraisalQuestion
    {
        public int AppraisalQuestionId { get; set; }
        public int AppraisalQuestionGroupId { get; set; }
        public int AppraisalQuestionTypeId { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }

        public int AppraisalId { get; set; }
        public Appraisal Appraisal { get; set; }

        public AssociateAppraisalQuestionAnswer AssociateAppraisalQuestionAnswer { get; set; }
    }
}
