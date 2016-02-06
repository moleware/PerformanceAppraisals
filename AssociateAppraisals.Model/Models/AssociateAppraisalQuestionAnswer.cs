using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociateAppraisals.Model
{
    public class AssociateAppraisalQuestionAnswer
    {
        public int AssociateAppraisalQuestionAnswerId { get; set; }
        public int AppraisalQuestionId { get; set; }
        public int AssociateAppraisalId { get; set; }
        public string Answer { get; set; }
    }
}
