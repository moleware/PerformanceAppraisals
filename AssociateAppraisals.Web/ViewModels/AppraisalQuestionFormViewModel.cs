using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AppraisalQuestionFormViewModel
    {
    //    [ForeignKey("Appraisal")]
        public int AppraisalId { get; set; }
  //      [ForeignKey("AppraisalQuestionGroup")]
        public int AppraisalQuestionGroupId { get; set; }
  //      [ForeignKey("AppraisalQuestionType")]
        public int AppraisalQuestionTypeId { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }
    }
}