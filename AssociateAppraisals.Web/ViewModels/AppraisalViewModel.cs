using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AppraisalViewModel
    {
        public int AppraisalId { get; set; }
        public int ReviewYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual List<AppraisalQuestionViewModel> Questions { get; set; }
    }
}