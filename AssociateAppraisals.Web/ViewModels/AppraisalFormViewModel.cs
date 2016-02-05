using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssociateAppraisals.Web.ViewModels
{
    public class AppraisalFormViewModel
    {
      //  public HttpPostedFileBase File { get; set; }
        public int ReviewYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}