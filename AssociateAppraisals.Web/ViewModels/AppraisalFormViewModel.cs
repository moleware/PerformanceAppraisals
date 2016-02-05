using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AppraisalQuestionFormViewModel
    {
        //  public HttpPostedFileBase File { get; set; }
        public int AppraisalId { get; set; }
        public int AppraisalQuestionGroupId { get; set; }
        public int AppraisalQuestionTypeId { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }
    }
}