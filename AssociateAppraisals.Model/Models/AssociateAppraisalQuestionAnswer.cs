using System.ComponentModel.DataAnnotations.Schema;
namespace AssociateAppraisals.Model
{
    using System;
    using System.Collections.Generic;

    [Table("AssociateAppraisalQuestionAnswer")]
    public class AssociateAppraisalQuestionAnswer
    {
        public int AssociateAppraisalQuestionAnswerId { get; set; }
        public int AppraisalQuestionId { get; set; }
        public int AssociateAppraisalId { get; set; }
        public string Answer { get; set; }

        public virtual AppraisalQuestion AppraisalQuestion { get; set; }
        public virtual AssociateAppraisal AssociateAppraisal { get; set; }
    }
}
