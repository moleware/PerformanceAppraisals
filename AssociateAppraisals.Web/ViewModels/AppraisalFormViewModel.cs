using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AppraisalFormViewModel
    {
        public int ReviewYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual List<AppraisalQuestion> Questions { get; set; }
    }
}