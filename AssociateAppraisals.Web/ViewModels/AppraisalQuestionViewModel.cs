using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AppraisalQuestionViewModel
    {
        public int AppraisalId { get; set; }
        public int AppraisalQuestionId { get; set; }
        public int AppraisalQuestionGroupId { get; set; }
        public int AppraisalQuestionTypeId { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }
    }
}